Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.Web.Script.Serialization
Imports Acordo.Enumeradores.Enumeradores

Public Class Componente

#Region "Variaveis"

    Private _tcpListener As TcpListener
    Private _IP As IPAddress = IPAddress.Parse("127.0.0.1")
    Private _porta As Integer

    Private _serializer As JavaScriptSerializer
    Private _localVirtualTime As Integer

    Private _listaPortasConectadas As List(Of Integer)

    Private _listaPortasValidas As List(Of Integer)

    Delegate Sub setStatusCallback([text] As String)

#End Region

#Region "Eventos"

    Private Sub Componente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _serializer = New JavaScriptSerializer
        _localVirtualTime = 0
        _listaPortasConectadas = New List(Of Integer)
        _listaPortasValidas = New List(Of Integer)({8000, 8001, 8002, 8003, 8004, 8005})
    End Sub

    Private Sub Componente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _tcpListener.Stop()
        Environment.Exit(0)
    End Sub

    Private Sub cmbPorta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPorta.SelectedIndexChanged
        Try
            conectaServidor(cmbPorta.SelectedItem)
            txtMensagem.Enabled = True
            btnEnviar.Enabled = True
            cmbPorta.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Porta já está em uso")
        End Try
    End Sub

    Private Sub txtMensagem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMensagem.KeyDown
        If e.KeyCode = Keys.KeyCode.Enter Then
            btnEnviar.PerformClick()
        End If
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        enviaMensagem(txtMensagem.Text, TipoEnvioMensagem.ativos)
        txtMensagem.Text = ""
    End Sub

#End Region

#Region "Metodos"

    Private Sub setStatus(ByVal text As String)
        If Me.txtStatus.InvokeRequired Then
            Dim d As New setStatusCallback(AddressOf setStatus)
            Me.Invoke(d, New Object() {text})
        Else
            Dim texto = ""
            If (Not String.IsNullOrEmpty(Me.txtStatus.Text)) Then
                texto &= vbCrLf
            End If
            texto &= text
            Me.txtStatus.AppendText(texto)
        End If
    End Sub

    Private Sub enviaMensagem(ByVal mensagem As String, Optional ByVal tipo As TipoEnvioMensagem = TipoEnvioMensagem.todos, Optional ByVal porta As Integer = 0)
        _localVirtualTime += 1
        Dim listaPortas = New List(Of Integer)
        If porta > 0 Then
            listaPortas.Add(porta)
        Else
            If tipo = TipoEnvioMensagem.todos Then
                listaPortas = _listaPortasValidas
            ElseIf tipo = TipoEnvioMensagem.ativos Then
                listaPortas = _listaPortasConectadas
            ElseIf tipo = TipoEnvioMensagem.todosMenosEu Then
                listaPortas = _listaPortasValidas.Where(Function(x) x <> _porta).ToList
            End If
        End If
        For Each porta In listaPortas
            Try
                Dim socketTcpCliente = New TcpClient()
                socketTcpCliente.Connect(_IP, porta)
                Dim networkStream As NetworkStream = socketTcpCliente.GetStream()

                ' cria objeto para mandar
                Dim dto As New Models.DTO
                dto.timeStamp = _localVirtualTime
                dto.mensagem = mensagem
                dto.porta = _porta
                'serializa objeto
                Dim resultado As String = _serializer.Serialize(dto)
                Dim sendBytes As [Byte]() = Encoding.UTF8.GetBytes(resultado)
                networkStream.Write(sendBytes, 0, sendBytes.Length)
                networkStream.Close()
                socketTcpCliente.Close()
            Catch ex As Exception
                ' servidor inativo
            End Try
        Next
    End Sub

    Private Function leMensagem(socket As TcpClient, stream As NetworkStream) As Models.DTO
        Dim bytes(socket.ReceiveBufferSize) As Byte
        stream.Read(bytes, 0, CInt(socket.ReceiveBufferSize))
        Dim returndata As String = Encoding.UTF8.GetString(bytes)
        Dim dto As Models.DTO = _serializer.Deserialize(Of Models.DTO)(returndata.Replace(vbNullChar, ""))
        Return dto
    End Function

    Private Sub conectaServidor(porta As Integer)
        _porta = porta
        ' inicia servidor na porta
        _tcpListener = New TcpListener(_IP, _porta)
        _tcpListener.Start()

        Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf esperaNovaConexao)
        ctThread.Start()

        _listaPortasConectadas.Add(_porta)

        Me.Text = "Componente " & _porta
        enviaMensagem("#porta", TipoEnvioMensagem.todosMenosEu)
    End Sub

    Private Sub esperaNovaConexao()
        While True
            Try
                Dim socket = _tcpListener.AcceptTcpClient()
                Dim dto As Models.DTO = leMensagem(socket, socket.GetStream)

                If dto.mensagem.Contains("#porta") Then
                    setStatus("Componente " & dto.porta & " entrou")
                    socket.Close()
                    Continue While
                End If
                If dto.mensagem.Contains("#desconectou") Then
                    setStatus("Componente " & dto.porta & " se desconectou")
                    _listaPortasConectadas.Remove(dto.porta)
                    socket.Close()
                    Continue While
                End If
                If dto.mensagem.Contains("#solicitandoacordo") Then
                    _listaPortasConectadas.Add(dto.porta)
                    socket.Close()
                    retornaAcordo(dto.porta)
                    Continue While
                End If
                If dto.mensagem.Contains("#retornandoacordo") Then
                    _listaPortasConectadas.Add(dto.porta)
                    socket.Close()
                    Continue While
                End If
                _localVirtualTime = Math.Max(_localVirtualTime, dto.timeStamp)
                setStatus("[" & dto.porta & "] " & dto.mensagem)
                socket.Close()
            Catch ex As Exception
                enviaMensagem("#desconectou", TipoEnvioMensagem.ativos)
            End Try
        End While
    End Sub

    Private Sub solicitaAcordo()
        enviaMensagem("#solicitandoacordo", TipoEnvioMensagem.todosMenosEu)
    End Sub

    Private Sub retornaAcordo(porta As Integer)
        enviaMensagem("#retornandoacordo", TipoEnvioMensagem.todosMenosEu, porta)
    End Sub

    Private Sub btnAcordo_Click(sender As Object, e As EventArgs) Handles btnAcordo.Click
        solicitaAcordo()
    End Sub

#End Region

End Class