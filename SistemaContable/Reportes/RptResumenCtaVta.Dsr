VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptResumenCtaVta 
   Caption         =   "SIGC - RptResumenCtaVta (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptResumenCtaVta.dsx":0000
End
Attribute VB_Name = "RptResumenCtaVta"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

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

Private Sub Detail_BeforePrint()
   Campo21.Text = txtres_acumulado.Text
End Sub

Private Sub Detail_Format()
   If lbl_param1.Caption = "1" Then
      If Field3.Text <= 3 Then
         Line4.Visible = True
         Line7.Visible = True
         Label23.Visible = True
         Label24.Visible = True
         Texto5.Visible = True
         Label6.Visible = True
         Label11.Visible = True
         Label22.Visible = True
         Label21.Visible = True
         Label20.Visible = True
         Sub1.Visible = True
         Shape3.Visible = True
         
         Me.Detail.Height = 600
      
         ''margen superior
         RptSubResumen.PageSettings.TopMargin = 300
         ''margen inferior
         RptSubResumen.PageSettings.BottomMargin = 300
         ''margen izquierdo
         RptSubResumen.PageSettings.LeftMargin = 650
         ''margen derecho
         RptSubResumen.PageSettings.RightMargin = 100
         ''NO TOCAR
         RptSubResumen.PageSettings.Gutter = 0
         RptSubResumen.DataControl1.ConnectionString = Cnn.ConnectionString
         RptSubResumen.DataControl1.Source = "SELECT * From MovVta Left Join Cliente on vta_ctacli = cli_codigo " _
         + "Left Join Zona on vta_zona = zon_codigo Left Join MovArtic on vta_codigo = his_codigo And " _
         + "vta_tipmov = his_tipmov And vta_cpbte = his_cpbte And vta_ctacli = his_ctacli Left Join (Localidad " _
         + "Left Join Provincia on loc_provin = pro_codigo) on vta_codpos1 = loc_cod1 And vta_codpos2 = loc_cod2 " _
         + "Left Join CondIva on vta_iva = iva_codigo Left Join (Articulo Left Join RubxLineaxFabrica on art_codtex = " _
         + "rlf_fabrica And art_linea = rlf_linea And rlf_rubro = '0') on his_codtex = art_codtex And " _
         + "his_codnum = art_codnum Left Join Fabrica on his_codtex = fab_codigo " _
         + "Where vta_ctacli = " & ctacli.Text & " And vta_cpbte = '" & txtres_nrocomp & "' Order by his_orden"
         
         Set Sub1 = RptSubResumen
      Else
         Line4.Visible = False
         Line7.Visible = False
         Label23.Visible = False
         Label24.Visible = False
         Texto5.Visible = False
         Label6.Visible = False
         Label11.Visible = False
         Label22.Visible = False
         Label21.Visible = False
         Label20.Visible = False
         Sub1.Visible = False
      End If
   Else
      Line4.Visible = False
      Line7.Visible = False
      Label23.Visible = False
      Label24.Visible = False
      Texto5.Visible = False
      Label6.Visible = False
      Label11.Visible = False
      Label22.Visible = False
      Label21.Visible = False
      Label20.Visible = False
      Sub1.Visible = False
      Shape3.Visible = False
      Me.Detail.Height = 75
   End If
End Sub

Private Sub PageFooter_BeforePrint()
   PaginaN.Caption = "Página " & Me.pageNumber
End Sub

Private Sub PageHeader_BeforePrint()
   If Me.pageNumber > 1 Then
      lbl_salini.Visible = False
      Label1.Visible = False
   End If
End Sub

Private Sub ReportFooter_BeforePrint()
   lbl_salfin.Text = Format(CDec(txtres_acumulado.Text), "#,##0.00")
   Campo18.Text = Format(CDec(Campo18.Text) + CDec(Debe.Caption), "#,##0.00")
   Campo19.Text = Format(CDec(Campo19.Text) + CDec(Haber.Caption), "#,##0.00")
End Sub
