Public Class LogicaPersona
    Public Sub altapersona (personita As personas) 
        Dim persistencia As New PersistenciaPersona
        Return.persistencia.Altapersona(personita)
    End Sub
    Public Function buscarPersona(ci As integer) As personas
        Dim persistencia As New PersistenciaPersona
        return.persistencia.Buscarpersona(ci)
    End Function
    Public Function ModificarPersonas(ci As Integer) As personas 
        Dim persistencia As New PersistenciaPersona  
        return.persistencia.ModificarPersonas()
    End Function 
End Class