Module MODFuncionesForm
    '' Esta clase contiene utilidades para los formularios de ABMC.

    Public Enum ModoPantalla As Byte ' Para unificar los modos en que puede estar un formulario ABMC
        ModoALTA = 0 ' En el ModoALTA el formulario tiene todos los campos en blanco
        ModoMODIFICACION = 1 ' En el ModoMODIFICACION los campos del formulario se cargan con los datos del elemento que se quiere modificar
        ModoCONSULTA = 2 ' En el ModoCONSULTA los campos del formulario se cargan con los datos del elemento, pero se bloquean para evitar su modificación
    End Enum

    Public Function AbmEvents_KP(ByVal Key As System.Windows.Forms.KeyEventArgs) As Integer
        '' Esta función agrega algunos comandos rápidos a los formularios ABMC.
        ''   Al presionar ENTER, pasamos al siguiente campo.
        ''   Al presionar ESCAPE, 

        AbmEvents_KP = 0

        If (Key.KeyCode = Keys.Enter) Then
            ' Si se presionó ENTER, cambialo por TAB
            SendKeys.Send("{TAB}")
        ElseIf (Key.KeyCode = Keys.Escape) Then
            ' Si se presionó ESCAPE, cambialo por +TAB
            SendKeys.Send("+{TAB}")
        End If
    End Function

    Public Sub DeshabilitarTextos(ByVal frm As Form)
        '' Este procedimiento deshabilita todos los campos de texto de un formulario ABMC.
        ''   Parámetros:
        ''   - frm: el formulario del cual se quieren deshabilitar las cajas de texto.

        For Each obj As Windows.Forms.Control In frm.Controls ' Para cada objeto en el formulario...
            If TypeOf obj Is GroupBox Then ' ... si el objeto es un GroupBox ...
                For Each txtBox As Windows.Forms.Control In obj.Controls ' ... para cada objeto del GroupBox...
                    If TypeOf txtBox Is TextBox Then ' ... si el objeto es una caja de texto...
                        CType(txtBox, TextBox).Enabled = False ' ... la deshabilito.
                    End If
                Next
            ElseIf TypeOf obj Is TextBox Then ' ... de otro modo, si el objeto es una caja de texto...
                CType(obj, TextBox).Enabled = False ' ... la deshabilito.
            End If
        Next
    End Sub

    Public Sub DeshabilitarCombos(ByVal frm As Form)
        '' Este procedimiento deshabilita todos las ComboBox de un formulario ABMC.
        ''   Parámetros:
        ''   - frm: el formulario del cual se quieren deshabilitar las ComboBox.

        For Each obj As Windows.Forms.Control In frm.Controls ' Para cada objeto en el formulario...
            If TypeOf obj Is GroupBox Then ' ... si el objeto es un GroupBox ...
                For Each combo As Windows.Forms.Control In obj.Controls ' ... para cada objeto del GroupBox...
                    If TypeOf combo Is ComboBox Then ' ... si el objeto es una ComboBox...
                        CType(combo, ComboBox).Enabled = False ' ... la deshabilito.
                    End If
                Next
            ElseIf TypeOf obj Is TextBox Then ' ... de otro modo, si el objeto es una ComboBox...
                CType(obj, TextBox).Enabled = False ' ... la deshabilito.
            End If
        Next
    End Sub

    Public Sub LimpiarTextos(ByVal frm As Form)
        '' Este procedimiento limpia todos los campos de texto de un formulario ABMC.
        ''   Parámetros:
        ''   - frm: el formulario del cual se quieren limpiar las cajas de texto.

        For Each obj As Windows.Forms.Control In frm.Controls ' Para cada objeto en el formulario...
            If TypeOf obj Is GroupBox Then ' ... si el objeto es un GroupBox ...
                For Each txtBox As Windows.Forms.Control In obj.Controls ' ... para cada objeto del GroupBox...
                    If TypeOf txtBox Is TextBox Then ' ... si el objeto es una caja de texto...
                        CType(txtBox, TextBox).Text = "" ' ... la limpio.
                    End If
                Next
            ElseIf TypeOf obj Is TextBox Then ' ... de otro modo, si el objeto es una caja de texto...
                CType(obj, TextBox).Text = "" ' ... la limpio.
            End If
        Next
    End Sub

    Public Sub HabilitarTextos(ByVal frm As Form)
        '' Este procedimiento habilita todos los campos de texto de un formulario ABMC.
        ''   Parámetros:
        ''   - frm: el formulario del cual se quieren habilitar las cajas de texto.

        For Each obj As Windows.Forms.Control In frm.Controls ' Para cada objeto en el formulario...
            If TypeOf obj Is GroupBox Then ' ... si el objeto es un GroupBox ...
                For Each txtBox As Windows.Forms.Control In obj.Controls ' ... para cada objeto del GroupBox...
                    If TypeOf txtBox Is TextBox Then ' ... si el objeto es una caja de texto...
                        CType(txtBox, TextBox).Enabled = True ' ... la habilito.
                    End If
                Next
            ElseIf TypeOf obj Is TextBox Then ' ... de otro modo, si el objeto es una caja de texto...
                CType(obj, TextBox).Enabled = True ' ... la habilito.
            End If
        Next
    End Sub

    Public Sub HabilitarCombos(ByVal frm As Form)
        '' Este procedimiento habilita todos las ComboBox de un formulario ABMC.
        ''   Parámetros:
        ''   - frm: el formulario del cual se quieren deshabilitar las ComboBox.

        For Each obj As Windows.Forms.Control In frm.Controls ' Para cada objeto en el formulario...
            If TypeOf obj Is GroupBox Then ' ... si el objeto es un GroupBox ...
                For Each combo As Windows.Forms.Control In obj.Controls ' ... para cada objeto del GroupBox...
                    If TypeOf combo Is ComboBox Then ' ... si el objeto es una ComboBox...
                        CType(combo, ComboBox).Enabled = True ' ... la habilito.
                    End If
                Next
            ElseIf TypeOf obj Is TextBox Then ' ... de otro modo, si el objeto es una ComboBox...
                CType(obj, TextBox).Enabled = True ' ... la habilito.
            End If
        Next
    End Sub

    Public Function esNumerico(ByVal str As String, ByVal entero As Boolean) As Boolean
        '' La función detecta si la cadena está compuesta por números.
        ''   Devuelve verdadero si la cadena está compuesta únicamente por valores numéricos y un punto decimal
        ''   Parámetros:
        ''   - str: cadena a analizar.
        ''   - entero: al especificarlo en verdadero, no se admite el punto decimal como un caracter numérico.


        If (str = "") Then
            ' Si la cadena está vacía, no es un número.
            Return False
        End If

        If (entero) Then
            ' No admito puntos decimales
            For Each num As Char In str
                ' Recorro cada caracter de la cadena
                If (num <> "0" And num <> "1" And num <> "2" And num <> "3" And num <> "4" And num <> "5" And num <> "6" And num <> "7" And num <> "8" And num <> "9") Then
                    ' Si no es un número devuelvo falso, de otro modo sigo recorriendo el string.
                    Return False
                End If
            Next
        Else
            ' Admito el punto decimal
            ' Creo una variable auxiliar para guardar cuando encuentre un punto
            Dim punto As Boolean
            punto = False

            For Each num As Char In str
                ' Recorro cada caracter de la cadena
                If (num <> "0" And num <> "1" And num <> "2" And num <> "3" And num <> "4" And num <> "5" And num <> "6" And num <> "7" And num <> "8" And num <> "9") Then
                    ' Si no es un número...
                    If (num = ",") Then
                        ' ... pero es un punto decimal ... 
                        If (punto) Then
                            ' ... y ya encontré otro, entonces el número es inválido.
                            Return False
                        Else
                            ' ... y no encontré ninguno, entonces lo guardo.
                            punto = True
                        End If
                    Else
                        Return False
                    End If
                End If
            Next
        End If

        ' Si todos los test anteriores no fallaron, significa que la cadena es un número.
        Return True
    End Function
End Module
