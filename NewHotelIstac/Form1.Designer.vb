<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Istac
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TextBoxStrConexion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePickerDesde = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBoxDebug = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxPais = New System.Windows.Forms.TextBox()
        Me.ButtonProcesar = New System.Windows.Forms.Button()
        Me.TextBoxDebug = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextBoxStrConexion
        '
        Me.TextBoxStrConexion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxStrConexion.Location = New System.Drawing.Point(80, 22)
        Me.TextBoxStrConexion.Name = "TextBoxStrConexion"
        Me.TextBoxStrConexion.Size = New System.Drawing.Size(672, 20)
        Me.TextBoxStrConexion.TabIndex = 0
        Me.TextBoxStrConexion.Text = "Provider=MSDAORA.1;User Id=RMC_MONICA;Password=RMC;Data Source = PORTATIL;;OLE DB" &
    " Services = -8;min pool size=0;Connection Timeout=10"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Conexión"
        '
        'DateTimePickerDesde
        '
        Me.DateTimePickerDesde.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerDesde.Location = New System.Drawing.Point(80, 58)
        Me.DateTimePickerDesde.Name = "DateTimePickerDesde"
        Me.DateTimePickerDesde.Size = New System.Drawing.Size(135, 20)
        Me.DateTimePickerDesde.TabIndex = 2
        Me.DateTimePickerDesde.Value = New Date(2017, 10, 26, 0, 0, 0, 0)
        '
        'DateTimePickerHasta
        '
        Me.DateTimePickerHasta.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerHasta.Location = New System.Drawing.Point(221, 58)
        Me.DateTimePickerHasta.Name = "DateTimePickerHasta"
        Me.DateTimePickerHasta.Size = New System.Drawing.Size(135, 20)
        Me.DateTimePickerHasta.TabIndex = 3
        Me.DateTimePickerHasta.Value = New Date(2017, 10, 26, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fechas"
        '
        'ListBoxDebug
        '
        Me.ListBoxDebug.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBoxDebug.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxDebug.FormattingEnabled = True
        Me.ListBoxDebug.ItemHeight = 14
        Me.ListBoxDebug.Location = New System.Drawing.Point(23, 96)
        Me.ListBoxDebug.Name = "ListBoxDebug"
        Me.ListBoxDebug.Size = New System.Drawing.Size(648, 172)
        Me.ListBoxDebug.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(415, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Pais (NACI_CODI)"
        '
        'TextBoxPais
        '
        Me.TextBoxPais.Location = New System.Drawing.Point(543, 58)
        Me.TextBoxPais.Name = "TextBoxPais"
        Me.TextBoxPais.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxPais.TabIndex = 7
        Me.TextBoxPais.Text = "ES"
        '
        'ButtonProcesar
        '
        Me.ButtonProcesar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonProcesar.Location = New System.Drawing.Point(677, 96)
        Me.ButtonProcesar.Name = "ButtonProcesar"
        Me.ButtonProcesar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonProcesar.TabIndex = 8
        Me.ButtonProcesar.Text = "&Procesar"
        Me.ButtonProcesar.UseVisualStyleBackColor = True
        '
        'TextBoxDebug
        '
        Me.TextBoxDebug.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxDebug.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.TextBoxDebug.Location = New System.Drawing.Point(23, 274)
        Me.TextBoxDebug.Name = "TextBoxDebug"
        Me.TextBoxDebug.Size = New System.Drawing.Size(648, 20)
        Me.TextBoxDebug.TabIndex = 9
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(13, 309)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(273, 101)
        Me.TextBox1.TabIndex = 10
        Me.TextBox1.Text = "Ojo empezar a leer el último dia del mes anterior , pero SOLO grabar mes actual, " &
    "es para arrancar con el acumulado de pernoctaciones del mes anterior correcto" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Istac
        '
        Me.AcceptButton = Me.ButtonProcesar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 412)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBoxDebug)
        Me.Controls.Add(Me.ButtonProcesar)
        Me.Controls.Add(Me.TextBoxPais)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListBoxDebug)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePickerHasta)
        Me.Controls.Add(Me.DateTimePickerDesde)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxStrConexion)
        Me.MinimumSize = New System.Drawing.Size(780, 341)
        Me.Name = "Istac"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxStrConexion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePickerDesde As DateTimePicker
    Friend WithEvents DateTimePickerHasta As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents ListBoxDebug As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxPais As TextBox
    Friend WithEvents ButtonProcesar As Button
    Friend WithEvents TextBoxDebug As TextBox
    Friend WithEvents TextBox1 As TextBox
End Class
