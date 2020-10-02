Public Class IngresePersona
    Dim listatelefonos As New list (of Integer)

    Private Sub IngresePersona_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

     Try
        Dim NombrePersona As String
        NombrePersona = NombrePersonaInput.Text

        Dim CIPersona As Integer
        CIPersona = Me.CIPersona.Text

        Dim DireccionPersona As String
        DireccionPersona = DireccionPersonaInput.Text

        Dim personanueva = New personas
        personanueva.Ci = CIPersona
        personanueva.Nombre = NombrePersona
        personanueva.direccion = DireccionPersona
        personanueva.ListaTelefono = listatelefonos


        Dim Logica = New LogicaPersona
        Logica.altapersona(personanueva)
      Catch ex As Exception
        
      End Try
   End sub

        Private Sub CIPersonaInput_TextChanged(sender As Object, e As EventArgs) Handles CIPersonaInput.TextChanged

        Dim cedula As integer
        cedula = CIPersonaInput.Text
        Dim personaNueva As personas 
        Dim logica As LogicaPersona
        personaNueva = logica.buscarPersonas(cedula)
        If  isNothing (personaNueva) Then 
            NombrePersonaInput.Ennabled = True
            DireccionPersonaInput.Enabled = True
            TelefonoPersonaInput.Enabled = True
            lv_telefono.Enabled = True
            AceptarPersonaBtn.Enabled = True
            ModificarPersona.Enabled = True
        else
            NombrePersonaInput.Text = personaNueva.Nombre
            DireccionPersonaInput.Text = personaNueva.direccion
        End if

        Dim telefonos As Integer  
        telefonos = telefonoPersonal_imput.next
        lv_telefono.Items.Add(telefonos)
        listatelefonos.Add (telefonos)

        telefonosPersonal_imput.Text = ""


        'Private Sub Persona_Load (sender As'
        'TelefonoPersonaInput.Enabled = False'
        'DireccionPersonaInput.Enabled = False'
        'NombrePersonaInput.Enabled = False'
        'lv_telefono.Enabled = False'
        'AceptarPersona'
      End Sub
End Class
