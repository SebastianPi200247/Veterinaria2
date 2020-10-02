Public Class PersistenciaPersona
    Dim conexion As Npgsql.NpgsqlConnection
    Public Function buscarPersona(cedula As Personas)
    End Function 
    Public Function listarPersona (cedula As integer) As List(of listPersonas)
    End Function
    Public Sub altapersona(personita As personas)
        Try
            Dim classcnn = New Conexion
            conexion = classcnn.AbrirConexion

            Dim cmd = New Npgsql.NpgsqlCommand
            cmd.Connection = conexion
            Dim cadenadecomando As String
            cadenadecomando = "insert into persona (ci,nombre,direccion) values(@ci,@nombre,@direccion);"
            cmd.CommandText = cadena_de_comandos

            cmd.Parameters.Add("@ci", NpgsqlTypes.NpgsqlDbType.Integer).Value = personita.Ci
            cmd.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = personita.Nombre
            cmd.Parameters.Add("@direccion", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = personita.direccion

            Dim resultado As Integer
            resultado = cmd.ExecuteNonQuery()

            If resultado = 1 Then
                Dim i = 0
                While i < personita.ListaTelefono.Count
                    cadenadecomando = "insert into telefonos (ci, telefono) values(@ci,@telefono);"
                    cmd.CommandText = cadena_de_comandos

                    cmd.Parameters.Add("@ci", NpgsqlTypes.NpgsqlDbType.Integer).Value = personita.Ci
                    cmd.Parameters.Add("@telefono", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = personita.ListaTelefono.Item(i)

                    resultado = cmd.ExecuteNonQuery()
                    i= i+1

                End While
            End If
        Catch ex As Exception
            Throw ex
        Finally
            conexion.Close()
        End Try
    End Sub

    Public Function Buscarpersona(ci As integer) As personas 
        Try
        Dim ClaseSln As New Conexion  
        conexion = ClaseSln.AbrirConexion
        Dim cmd As NpgsqlCommand 
        cmd.Connection = conexion
    
        Dim CadenaDeComandos = "Select * from persona where cedulapersona = @ci "
        cmd.CommandText= CadenaDeComandos 
        cmd.Parameters.add("@ci", NpgsqlTypes.NpgsqlDbType.Integer).Value = ci
        Dim lector As npgsql.DataReader = cmd.ExecuteReader
        Dim personaNueva As personas

    If lector.hasRows Then 
        lector.Read()
        personaNueva.Ci = Convert.ToInt32(lector(0).ToString)
        personaNueva.Nombre = lector(1).ToString
        personaNueva.direccion =lector(2).ToString

    End if
    Catch ex As Exception
     
    Finally
    Return personaNueva
    End Try
    End Function
End Class
