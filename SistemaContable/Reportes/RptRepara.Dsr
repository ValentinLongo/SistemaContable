VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptRepara 
   Caption         =   "SIGC - RptRepara (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptRepara.dsx":0000
End
Attribute VB_Name = "RptRepara"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub ActiveReport_ReportStart()
   If Len(ParCerosCant) > 0 Then
      txthis_cantidad.OutputFormat = "0." & ParCerosCant
   End If
End Sub

Private Sub PageHeader_Format()
   If lbl_param1.Caption = "1" Then
      Dim lW As Long, lH As Long
      lW = 6200
      lH = 2400
      With Canvas
          .Font.Size = 60
          .TextAngle = 450
          .MeasureText "FINALIZADO", lW, lH
          .ForeColor = &HE0E0E0
          '.DrawText "Proveedores", (Me.PrintWidth - lW) / 2, (Me.Printer.PaperHeight - lH) / 2, lW, lH
          .DrawText "FINALIZADO", 2 * 1440, 3 * 1440, 7 * 1440, 4 * 1440
      End With
   End If
End Sub

