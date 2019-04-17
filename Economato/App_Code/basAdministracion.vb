Module basAdministracion
    Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
    'Public entorno As String = CType(configurationAppSettings.GetValue("Entorno", GetType(System.String)), String)
    Public bases As String = CType(configurationAppSettings.GetValue("Bases", GetType(System.String)), String)
    Public LoginPage As String = CType(configurationAppSettings.GetValue("LoginPage", GetType(System.String)), String)
    Public Sistema As String = CType(configurationAppSettings.GetValue("Sistema", GetType(System.String)), String)
    Public cdSistema As String = CType(configurationAppSettings.GetValue("cdSistema", GetType(System.String)), String)
    Public URLRegistracion = CType(configurationAppSettings.GetValue("URLRegistracion", GetType(System.String)), String)
End Module
