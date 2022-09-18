Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports Microsoft.OpenApi.Models

Namespace WhatsappChatbotVB
    Public Class Startup
        Public Sub New(ByVal configuration As IConfiguration)
            Me.Configuration = configuration
        End Sub

        Public ReadOnly Property Configuration As IConfiguration

        ' This method gets called by the runtime. Use this method to add services to the container.
        Public Sub ConfigureServices(ByVal services As IServiceCollection)

            services.AddControllers()
            services.AddSwaggerGen(Sub(c) c.SwaggerDoc("v1", New OpenApiInfo With {
.Title = "WhatsappChatbotVB",
.Version = "v1"
}))
            services.AddTransient(Of ChatService)()
            services.Configure(Of AppSettings)(Configuration.GetSection("AppSettings"))
        End Sub

        ' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IWebHostEnvironment)
            If env.IsDevelopment() Then
                app.UseDeveloperExceptionPage()
                app.UseSwagger()
                app.UseSwaggerUI(Sub(c) c.SwaggerEndpoint("/swagger/v1/swagger.json", "WhatsappChatbotVB v1"))
            End If

            app.UseHttpsRedirection()

            app.UseRouting()

            app.UseAuthorization()

            app.UseEndpoints(Sub(endpoints) endpoints.MapControllers())
        End Sub
    End Class
End Namespace
