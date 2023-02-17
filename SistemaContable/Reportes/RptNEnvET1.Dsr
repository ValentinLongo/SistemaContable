VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptNEnvET1 
   Caption         =   "SIGC - RptNEnvET1 (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   20400
   _ExtentX        =   35983
   _ExtentY        =   19076
   SectionData     =   "RptNEnvET1.dsx":0000
End
Attribute VB_Name = "RptNEnvET1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub PageHeader_BeforePrint()
   If Trim(ObsCli.Text) = "" Then
      ObsCli.Visible = False
   Else
      ObsCli.Visible = True
   End If
End Sub

