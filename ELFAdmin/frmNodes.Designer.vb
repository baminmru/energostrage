<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNodes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.GV = New System.Windows.Forms.DataGridView()
        Me.cmdSetupNode = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkActiveNode = New System.Windows.Forms.CheckBox()
        CType(Me.GV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdDel
        '
        Me.cmdDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDel.Location = New System.Drawing.Point(407, 313)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(105, 30)
        Me.cmdDel.TabIndex = 15
        Me.cmdDel.Text = "Удалить"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Location = New System.Drawing.Point(283, 313)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(104, 30)
        Me.cmdAdd.TabIndex = 10
        Me.cmdAdd.Text = "Добавить"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'GV
        '
        Me.GV.AllowUserToAddRows = False
        Me.GV.AllowUserToDeleteRows = False
        Me.GV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.GV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.GV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GV.Location = New System.Drawing.Point(12, 65)
        Me.GV.MultiSelect = False
        Me.GV.Name = "GV"
        Me.GV.ReadOnly = True
        Me.GV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GV.Size = New System.Drawing.Size(498, 235)
        Me.GV.TabIndex = 8
        '
        'cmdSetupNode
        '
        Me.cmdSetupNode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSetupNode.Location = New System.Drawing.Point(151, 313)
        Me.cmdSetupNode.Name = "cmdSetupNode"
        Me.cmdSetupNode.Size = New System.Drawing.Size(113, 29)
        Me.cmdSetupNode.TabIndex = 32
        Me.cmdSetupNode.Text = "Открыть"
        Me.cmdSetupNode.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(191, 9)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(321, 20)
        Me.txtFilter.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Фильтр (минимум 3 символа):"
        '
        'chkActiveNode
        '
        Me.chkActiveNode.AutoSize = True
        Me.chkActiveNode.Checked = True
        Me.chkActiveNode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActiveNode.Location = New System.Drawing.Point(26, 42)
        Me.chkActiveNode.Name = "chkActiveNode"
        Me.chkActiveNode.Size = New System.Drawing.Size(115, 17)
        Me.chkActiveNode.TabIndex = 35
        Me.chkActiveNode.Text = "Только активные"
        Me.chkActiveNode.UseVisualStyleBackColor = True
        '
        'frmNodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 349)
        Me.Controls.Add(Me.chkActiveNode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.cmdSetupNode)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.GV)
        Me.Name = "frmNodes"
        Me.Text = "Узлы"
        CType(Me.GV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents GV As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSetupNode As System.Windows.Forms.Button
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkActiveNode As CheckBox
End Class
