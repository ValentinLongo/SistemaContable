VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptResumenCta 
   Caption         =   "SIGC - RptResumenCta (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptResumenCta.dsx":0000
End
Attribute VB_Name = "RptResumenCta"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub ActiveReport_ReportEnd()
   Dim pdf As New ActiveReportsPDFExport.ARExportPDF
   Set pdf = New ActiveReportsPDFExport.ARExportPDF
End Sub

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
   Menu.Dialog1.FileName = "Resumen de Cuentas.pdf"
   On Error Resume Next
   Menu.Dialog1.CancelError = True
   Menu.Dialog1.ShowSave
   If Err.Number = 32755 Then
      Err.Clear
      Exit Sub
   End If
   If Right(Menu.Dialog1.FileName, 4) <> ".pdf" Then
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
   Menu.Dialog1.FileName = "Resumen de Cuentas.xls"
   On Error Resume Next
   Menu.Dialog1.CancelError = True
   Menu.Dialog1.ShowSave
   If Err.Number = 32755 Then
      Err.Clear
      Exit Sub
   End If
   If Right(Menu.Dialog1.FileName, 4) <> ".xls" Then
      Menu.Dialog1.FileName = Menu.Dialog1.FileName & ".xls"
   End If
   Exc.FileName = Menu.Dialog1.FileName
   Exc.Export Me.Pages
   MsgBox "Atención: La Exportación fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atención: Ocurrió un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub Detail_AfterPrint()
   If lbl_param1.Caption = "1" Then
      Set Sub1 = Nothing
   End If
End Sub

Private Sub Detail_Format()
   If lbl_param1.Caption = "1" Then
      Line7.Visible = True
      Line8.Visible = True
      Label23.Visible = True
      Label25.Visible = True
      Label24.Visible = True
      Label22.Visible = True
      Label32.Visible = True
      Label28.Visible = True
      Label21.Visible = True
      Label20.Visible = True
      Sub1.Visible = True
      Shape2.Visible = True
      
      Me.Detail.Height = 690
   
      Config_Hoja RptSubResumenCpa
      RptSubResumenCpa.DataControl1.ConnectionString = Cnn.ConnectionString
      RptSubResumenCpa.DataControl1.Source = "Select * From MaesStock Left Join Transporte on mas_transp1 = tra_codigo " _
      + "Left Join Usuario on mas_usuario1 = usu_codigo Left Join DetStock on mas_codigo = des_codigo Left Join " _
      + "(Proveedor Left Join CondIva on prv_iva = iva_codigo Left Join (Localidad Left Join Provincia on loc_provin = " _
      + "pro_codigo) on prv_codpos1 = loc_cod1 And prv_codpos2 = loc_cod2) on mas_ctapro = prv_codigo Left Join Articulo " _
      + "on des_codtex = art_codtex AND des_codnum = art_codnum Left Join Fabrica on des_codtex = fab_codigo " _
      + "Where mas_ctapro = " & ctacli.Text & " And mas_cpbte = '" & txtres_nrocomp.Text & "' Order By des_orden"
      
      Set Sub1 = RptSubResumenCpa
   Else
      Line7.Visible = False
      Line8.Visible = False
      Label23.Visible = False
      Label25.Visible = False
      Label24.Visible = False
      Label22.Visible = False
      Label32.Visible = False
      Label28.Visible = False
      Label21.Visible = False
      Label20.Visible = False
      Sub1.Visible = False
      Shape2.Visible = False
      Me.Detail.Height = 90
   End If
End Sub

Private Sub Detail_BeforePrint()
   If CDec(txtres_dtos.Text) = 0 Then
      txtres_dtos.Text = ""
   End If
End Sub

Private Sub PageFooter_BeforePrint()
   PaginaN.Caption = "Página " & Me.pageNumber
End Sub
