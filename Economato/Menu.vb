Public Class Menu
    Private _ColElementos As System.Collections.ArrayList
    Sub New()
        ColElementos = New ArrayList
    End Sub
    Public Property ColElementos() As System.Collections.ArrayList  ' Nome do atributo criado 
        Get
            Return _ColElementos
        End Get
        Set(ByVal Value As System.Collections.ArrayList)
            _ColElementos = Value
        End Set
    End Property
    Public Sub RemoveElemento(ByVal cdElemento As Integer)
        Dim oElemento As OpcionMenu
        For Each oElemento In Me._ColElementos
            If oElemento.cdElemento = cdElemento Then
                _ColElementos.Remove(oElemento)
                Exit Sub
            End If
        Next
    End Sub
    Public Sub AgregarElemento(ByVal Value As OpcionMenu)
        Dim oElemento As OpcionMenu
        If Not IsNothing(_ColElementos) Then
            For Each oElemento In _ColElementos
                If oElemento.cdElemento = Value.cdElemento Then
                    Exit Sub
                End If
            Next
        End If
        _ColElementos.Add(Value)
    End Sub
End Class
