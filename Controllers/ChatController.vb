Imports Microsoft.AspNetCore.Mvc

Namespace WhatsappChatbotVB.Controllers
    <Route("api/")>
    <ApiController>
    Public Class ChatController
        Inherits ControllerBase
        Private ReadOnly _chatService As ChatService

        Public Sub New(ByVal chatService As ChatService)
            _chatService = chatService
        End Sub
        <HttpGet("{number}/{id}")>
        Public Function OnChat(ByVal number As String, id As String) As IActionResult
            Dim result = _chatService.OnChat(number, id)
            Return MyBase.Ok(result)
        End Function


    End Class
End Namespace
