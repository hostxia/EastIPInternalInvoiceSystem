;#DropDB EastIPInternalInvoiceSystemEasyTest

#Application EastIPInternalInvoiceSystem.Win
#Application EastIPInternalInvoiceSystem.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef EastIPInternalInvoiceSystem.Win

*Action About...
 
*Action OK

#EndIf

#IfDef EastIPInternalInvoiceSystem.Web
*Action Navigation(My Details)
#EndIf
