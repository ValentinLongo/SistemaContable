VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptRemito 
   Caption         =   "SIGC - RptRemito (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   20400
   _ExtentX        =   35983
   _ExtentY        =   19076
   SectionData     =   "RptRemito.dsx":0000
End
Attribute VB_Name = "RptRemito"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub ActiveReport_ReportStart()
   Me.Toolbar.Tools.AddEx("&PDF").Tooltip = "Exportar a PDF"
   Me.Toolbar.Tools.AddEx("&Excel").Tooltip = "Exportar a Excel"
   If Len(ParCerosCant) > 0 Then
      txthis_cantidad.OutputFormat = "0." & ParCerosCant
   End If
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
   Menu.Dialog1.FileName = "Comprobante.pdf"
   Menu.Dialog1.ShowSave
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
   Menu.Dialog1.FileName = "Comprobantes.xls"
   Menu.Dialog1.ShowSave
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
   On Error Resume Next
   
   If txthis_codtex.Text = "0" Then txthis_codtex.Text = ""
   If txthis_codnum.Text = "88888888" Then txthis_codnum.Text = ""
   
   txthis_dtoCondA = IIf((txthis_dtoCondA) = "", 0, txthis_dtoCondA)
   txthis_dtoCondB = IIf((txthis_dtoCondB) = "", 0, txthis_dtoCondB)
   txthis_dtoCondC = IIf((txthis_dtoCondC) = "", 0, txthis_dtoCondC)
   txthis_dtoCondD = IIf((txthis_dtoCondD) = "", 0, txthis_dtoCondD)
   txtDtos.Text = IIf((txthis_dtoa = 0), "", Format(txthis_dtoa, "0.00")) _
   & IIf((txthis_dtob = 0), "", " " & Format(txthis_dtob, "0.00")) _
   & IIf((txthis_dtoc = 0), "", " " & Format(txthis_dtoc, "0.00")) _
   & IIf((txthis_dtod = 0), "", " " & Format(txthis_dtod, "0.00")) _
   & IIf((txthis_dtoe = 0), "", " " & Format(txthis_dtoe, "0.00")) _
   & IIf((txthis_dtof = 0), "", " " & Format(txthis_dtof, "0.00")) _
   & IIf((txthis_dtoCondA = 0), "", " " & Format(txthis_dtoCondA, "0.00")) _
   & IIf((txthis_dtoCondB = 0), "", " " & Format(txthis_dtoCondB, "0.00")) _
   & IIf((txthis_dtoCondC = 0), "", " " & Format(txthis_dtoCondC, "0.00")) _
   & IIf((txthis_dtoCondD = 0), "", " " & Format(txthis_dtoCondD, "0.00")) _
   & IIf((txthis_dtoctdo = 0), "", " " & Format(txthis_dtoctdo, "0.00"))
   'If Trim(txtDtos.Text) = "" Then Exit Sub
   'txtDtos.Text = IIf((Left(txtDtos.Text, 1) = "+"), Right(txtDtos.Text, Len(txtDtos.Text) - 1), txtDtos.Text)

   If CDec(Trim(txthis_cantidad.Text)) = 0 Then
      txthis_cantidad.Text = ""
      txthis_aliva.Text = ""
      txthis_punitario.Text = ""
      txthis_total.Text = ""
      txthis_preclista.Text = ""
      txtDtos.Text = ""
   End If

End Sub

Private Sub PageHeader_Format()
   Dim RstCanvas As ADODB.Recordset
   Set RstCanvas = New ADODB.Recordset
   If RstCanvas.State = 1 Then RstCanvas.Close
   RstCanvas.Open "Select * From PtoVtaxTipMov Where ptc_tipcpbte = 7 And ptc_ptovta = " & CLng(IIf((Trim(Mid(Cpbte.Text, 2, 4)) = ""), 0, Trim(Mid(Cpbte.Text, 2, 4)))), Cnn, adOpenStatic, adLockReadOnly, adCmdText
   Dim Imprime As Boolean
   Imprime = False
   If Not RstCanvas.EOF And Not IsNull(RstCanvas!ptc_marcaagua) Then
      Select Case RstCanvas!ptc_marcaagua
         Case Is = 0
            Imprime = True
         Case Is = 1
            If UCase(Leyenda.Text) = "ORIGINAL" Then
               Imprime = True
            End If
         Case Is = 2
            If UCase(Leyenda.Text) = "DUPLICADO" Then
               Imprime = True
            End If
         Case Is = 3
            If UCase(Leyenda.Text) = "TRIPLICADO" Then
               Imprime = True
            End If
         Case Else
            If UCase(Leyenda.Text) = "COPIA" Then
               Imprime = True
            End If
      End Select
   End If
   
   If Imprime = True Then
      Dim lW As Long, lH As Long
      lW = 6200
      lH = 2400
      With Canvas
          .Font.Size = 55
          .TextAngle = 450
          .MeasureText UCase(Leyenda.Text), lW, lH
          .ForeColor = &HE0E0E0
          .DrawText UCase(Leyenda.Text), 2 * 1440, 3 * 1440, 7 * 1440, 4 * 1440
      End With
   End If
End Sub

