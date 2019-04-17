Public Class OpcionMenu
    Private _cdElemento As Integer ' Variavel interna da classe 
    Private _dsElemento As String ' Variavel interna da classe 


    Sub New(ByVal pcdElemento As Integer, ByVal pdsElemento As String, ByVal pdsPagina As String)
        _cdElemento = pcdElemento
        _dsElemento = pdsElemento
        _dsPagina = pdsPagina
    End Sub
    Public Property cdElemento() As Integer
        Get
            Return _cdElemento
        End Get
        Set(ByVal Value As Integer)
            _cdElemento = Value
        End Set
    End Property
    Public Property dsElemento() As String  ' Nome do atributo criado 
        Get
            Return _dsElemento
        End Get
        Set(ByVal Value As String)
            _dsElemento = Value
        End Set
    End Property
    Dim _dsPagina As String
    Public Property dsPagina() As String  ' Nome do atributo criado 
        Get
            Return _dsPagina
        End Get
        Set(ByVal Value As String)
            _dsPagina = Value
        End Set
    End Property


End Class
