VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptLibIvaV 
   Caption         =   "SIGC - RptLibIvaV (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   20400
   _ExtentX        =   35983
   _ExtentY        =   19076
   SectionData     =   "RptLibIvaV.dsx":0000
End
Attribute VB_Name = "RptLibIvaV"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Fecha As String

Private Sub ActiveReport_ReportStart()
   Me.Toolbar.Tools.AddEx("&PDF").Tooltip = "Exportar a PDF"
   Me.Toolbar.Tools.AddEx("&Excel").Tooltip = "Exportar a Excel"
End Sub

Private Sub ActiveReport_ToolbarClick(ByVal Tool As DDActiveReports2.DDTool)
   Select Case Tool.Caption
      Case Is = "&PDF"
         tbPDFExport
      Case Is = "&Excel"
         tbExcel
   End Select
End Sub

Private Sub tbPDFExport()
On Error GoTo fin
   Dim pdf As New ActiveReportsPDFExport.ARExportPDF
   Set pdf = New ActiveReportsPDFExport.ARExportPDF
   Menu.Dialog1.Filter = "(*.pdf)|*.pdf|"
   Menu.Dialog1.FileName = "Libros de IVA.pdf"
   On Error Resume Next
   Menu.Dialog1.CancelError = True
   Menu.Dialog1.ShowSave
   If Err.Number = 32755 Then
      Err.Clear
      Exit Sub
   End If
   If right(Menu.Dialog1.FileName, 4) <> ".pdf" Then
      Menu.Dialog1.FileName = Menu.Dialog1.FileName & ".pdf"
   End If
   pdf.FileName = Menu.Dialog1.FileName
   pdf.Export Me.Pages
   MsgBox "Atención: La Exportación fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atención: Ocurrió un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub tbExcel()
On Error GoTo fin
   Dim Exc As New ActiveReportsExcelExport.ARExportExcel
   Set Exc = New ActiveReportsExcelExport.ARExportExcel
   Menu.Dialog1.Filter = "(*.xls)|*.xls|"
   Menu.Dialog1.FileName = "Libros de IVA.xls"
   On Error Resume Next
   Menu.Dialog1.CancelError = True
   Menu.Dialog1.ShowSave
   If Err.Number = 32755 Then
      Err.Clear
      Exit Sub
   End If
   If right(Menu.Dialog1.FileName, 4) <> ".xls" Then
      Menu.Dialog1.FileName = Menu.Dialog1.FileName & ".xls"
   End If
   Exc.FileName = Menu.Dialog1.FileName
   Exc.Export Me.Pages
   MsgBox "Atención: La Exportación fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atención: Ocurrió un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub Detail_BeforePrint()
   If txtvta_cliente.Text = "ANULADO" Then
      txtCond.Visible = False
      txtCUIT.Visible = False
      txttmo_abrev.Visible = False
      Me.txtNeto.Visible = False
      Me.txtvta_exento.Visible = False
      Me.txtvta_neto21.Visible = False
      Me.Field2.Visible = False
      Me.Field3.Visible = False
      
      Me.txtvta_total.Visible = False
   Else
      txtCond.Visible = True
      txtCUIT.Visible = True
      txttmo_abrev.Visible = True
      Me.txtNeto.Visible = True
      Me.txtvta_exento.Visible = True
      Me.txtvta_neto21.Visible = True
      Me.Field2.Visible = True
      Me.Field3.Visible = True
      Me.txtvta_total.Visible = True
   End If

'   If Fecha = txtvta_fecpro Then
'      txtvta_fecpro.Visible = False
'   Else
'      txtvta_fecpro.Visible = True
'      Fecha = txtvta_fecpro
'   End If
End Sub

Private Sub PageFooter_BeforePrint()
   If Field1 <> Total Then
      Texto18.Caption = "Transporte :"
      If frm_libivav.chk_impt.Value = 0 Then
         Texto18.Visible = False
         Campo27.Visible = False
         Campo23.Visible = False
         Campo24.Visible = False
         Field4.Visible = False
         Field5.Visible = False
         Campo26.Visible = False
         'Line2.Visible = False
      Else
         Texto18.Visible = True
         Campo27.Visible = True
         Campo23.Visible = True
         Campo24.Visible = True
         Field4.Visible = True
         Field5.Visible = True
         Campo26.Visible = True
         'Line2.Visible = True
      End If
   Else
      Texto18.Caption = "Totales :"
   End If
   
   If Field1 = Total Then ''ARREGLOS TOVO
'      Campo27.Text = Format(CDec(Campo27.Text) - 58537.79, "#,##0.00")
'      Campo24.Text = Format(CDec(Campo24.Text) - 12292.94, "#,##0.00")
'      Campo26.Text = Format(CDec(Campo26.Text) - 70830.73, "#,##0.00")
      
'      Campo27.Text = Format(CDec(Campo27.Text) - 74128.56, "#,##0.00")
'      Campo24.Text = Format(CDec(Campo24.Text) - 15567, "#,##0.00")
'      Campo26.Text = Format(CDec(Campo26.Text) - 89695.56, "#,##0.00")
   
'      Campo27.Text = Format(CDec(Campo27.Text) - 68000, "#,##0.00")
'      Campo24.Text = Format(CDec(Campo24.Text) - 14280, "#,##0.00")
'      Campo26.Text = Format(CDec(Campo26.Text) - 82280, "#,##0.00")
   End If
End Sub

Private Sub PageHeader_BeforePrint()
   On Error Resume Next
   Me.Pagina.Text = Format(CInt(Me.pageNumber) + CInt(Me.lbl_page), "00000000")
   If Not Trim(Me.pagina1.Text) = "" Then
      Me.pagina1.Text = Me.pagina1.Text + CInt(Me.pageNumber)
   Else
      Me.pagina1.Visible = False
   End If
End Sub


