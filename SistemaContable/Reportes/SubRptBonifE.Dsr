VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} SubRptBonifE 
   Caption         =   "SIGC - SubRptBonifE (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "SubRptBonifE.dsx":0000
End
Attribute VB_Name = "SubRptBonifE"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Detail_BeforePrint()
   Select Case txtvta_iva.Text
      Case Is = 1
         txtvta_iva.Text = "RI"
      Case Is = 2
         txtvta_iva.Text = "NRI"
      Case Is = 3
         txtvta_iva.Text = "CF"
      Case Is = 4
         txtvta_iva.Text = "EX"
      Case Is = 5
         txtvta_iva.Text = "NR"
      Case Is = 6
         txtvta_iva.Text = "MT"
   End Select
End Sub

