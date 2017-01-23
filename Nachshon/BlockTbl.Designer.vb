<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BlockTbl
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Img = New System.Windows.Forms.DataGridViewImageColumn
        Me.AcadBlock = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Length = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Width = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Height = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.KW = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HP = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowDrop = True
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Img, Me.AcadBlock, Me.Description, Me.Length, Me.Width, Me.Height, Me.KW, Me.HP})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.Size = New System.Drawing.Size(891, 477)
        Me.DataGridView1.TabIndex = 0
        '
        'Img
        '
        Me.Img.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Img.HeaderText = "Img"
        Me.Img.Name = "Img"
        Me.Img.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Img.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Img.Width = 55
        '
        'AcadBlock
        '
        Me.AcadBlock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.AcadBlock.HeaderText = "AcadBlock"
        Me.AcadBlock.Name = "AcadBlock"
        Me.AcadBlock.Width = 99
        '
        'Description
        '
        Me.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.Width = 104
        '
        'Length
        '
        Me.Length.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Length.HeaderText = "Length"
        Me.Length.Name = "Length"
        '
        'Width
        '
        Me.Width.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Width.HeaderText = "Width"
        Me.Width.Name = "Width"
        '
        'Height
        '
        Me.Height.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Height.HeaderText = "Height"
        Me.Height.Name = "Height"
        '
        'KW
        '
        Me.KW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.KW.HeaderText = "KW"
        Me.KW.Name = "KW"
        '
        'HP
        '
        Me.HP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.HP.HeaderText = "HP"
        Me.HP.Name = "HP"
        '
        'BlockTbl
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 477)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.Name = "BlockTbl"
        Me.Text = "Block Table"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Img As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents AcadBlock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Length As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Width As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Height As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KW As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HP As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
