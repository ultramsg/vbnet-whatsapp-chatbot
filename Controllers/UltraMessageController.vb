Imports Microsoft.AspNetCore.Mvc
Imports System
Imports System.Text.Json

Namespace WhatsappChatbotVB.Properties
    <Route("api/")>
    <ApiController>
    Public Class UltraMessageController
        Inherits ControllerBase
        Private ReadOnly _chatService As ChatService
        Public Sub New(ByVal chatService As ChatService)
            _chatService = chatService
        End Sub
        <HttpPost>
        Public Function Post(
        <FromBody> ByVal data As HookData) As IActionResult
            Dim result = _chatService.OnChat(data.Data.From, data.Data.Body)
            Console.WriteLine(JsonSerializer.Serialize(data))
            Return MyBase.Ok(data)
        End Function
    End Class
End Namespace
