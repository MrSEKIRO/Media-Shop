   M S B A M L   `   `   `  ���� >  :HW6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HW6HW6      	HW6.Admin   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     #localclr-namespace:HW6       � Title$  Admin��$	��500��$	��800�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=�.��� .+��  � ColumnDefinitions �� $	��.2* ��� .+��� $��0��.+��� -    ��Name$ btnADD��$	��ADD��$��13,17q�$��15,10q��� -   $ 	btnDELETE��$��DELETE��$��13,17q�$��15,10q��� -   $ 	btnSEARCH��$��SEARCH��$��13,17q�$��15,10q��� -   $ btnSHOWCUSTOMERS��$��SHOWCUSTOMERS��$��13,17q�$
��0,10q��� -   $ btnCHANGEPASS��$��
CHANGEPASS��$��13,17q�$
��0,10q��� -   $ btnAdminExit��$
��Exit��$��13,17q�$��15,10q��� -    ��Name$ TabctrlAdmin��$��1��$��Segoe UI Semibold)�$��1,0,-1.4,0.4q�.@��� -    ��Name$ TabAdmin_welcom��$y�	Collapsed=�.���� -	    ��Name$ txtblkWelcom��$��
Welcom ...��$��Center=�$��Center=�$��86��$	��4,0q�$	��648��$��48(����	#FF00BDB3$��Forte)��� -
   $ TabADD��$y�	Collapsed=�.���  � RowDefinitions �� $
��1.5* ��� $��2* ��� �� �� �� �� �� $
��2.5* �.+��� $��0��$��Choose your media type:��$��Center=�$��Center=�$��24(����	#FF208C31� $��1�� �� �� �� .+��� -   $ btnMagazine��$��0��$��Magazine��$��34,14,31.4,13.2q����	#FF45FA16���	#FF2D8E00$��20(�$��Showcard Gothic)��� -   $ btnBook��$��1��$
��Book��$��30.6,15,28.6,14.2q����	#FF40FF0F$��20(�$��Showcard Gothic)���Z� �� -   $ btnVideo��$��2��$��Video��$��21.4,15,28,14.2q����	#FF40FF0F$��20(�$��Showcard Gothic)���Z� � $��2�� �� �� $
��1.5* �.+��� $��0��$��Name:��$��178,10,7.4,-0.4q�$��Sylfaen)�$��16(��� -   	 ��Name$	 
txtboxName��$��1��$��9.6,14,161,5.6q�� $��3�� �� �� $
��1.5* �.+��� $��0��$	��Id:��$��178,10,8.4,-0.4q�$��Sylfaen)�$��16(��� -   $	 txtboxADD_Id��$��1��$��9.6,14,162,5.6q�� $��4�� �� �� $
��1.5* �.+��� $��0��$��Price:��$��178,10,7.4,-0.4q�$��Sylfaen)�$��16(��� -   $	 txtboxPrice��$��1��$��9.6,14,165,5.6q�� $��5�� �� �� $
��1.5* �.+��� -   
 ��Name$
 lblADD_Info1��$��0��$��info1:��$��178,10,6.4,-0.4q�$��Sylfaen)�$��16(��� -   $	 txtboxInfo1��$��1��$��9.6,14,164,5.6q�� $��6�� �� �� $
��1.5* �.+��� -   $
 lblADD_Info2��$��0��$��info2:��$��178,10,386,-0.4q�$��2��$��Sylfaen)�$��16(��� -   $	 txtboxInfo2��$��1��$��9.6,14,166,5.6q�� $��7�� �� �� .+�� $��0�� �� �� .+��� -   $ 
btnADD_add��$��0��$	��Add��$��216,10,21,9.8q��� -   $ btnADD_clear��$��1��$��Clear��$��0,10,240,9.8q� J� RenderTransformOrigin$ 	0.5,0.503&��� -   $
 lblADD_resualt��$��1��$�� ��$��181,5.2,201,20.8q��� -   $ 	TabDELETE��$y�	Collapsed=�.���  �� $��2* ��� �� �� .+��� $��0��$(��"Enter ID of Media you want delete:��$��130,80,145,60.2q�$��24(�� $��1�� �� �� $
��1.5* �.+��� $��0��$��ID��$��238,31,0.4,41q�$��Sylfaen)�$��16(��� -   $	 txtboxDelete��$��1��$��10.6,32,186,40q��� -   $ btnDel_Delete��$��1��$��Delete��$��247,91.8,264,48.2q�$��2���� -   $
 lblDel_resualt��$��3��$�� ��$��214,9.8,223,55.4q����	#FFDC0E0E�� -   $ 	TabSEARCH��$y�	Collapsed=�.���  �� $��1* ��� �� �� $��2* �.+��� $��0��$��Search Engine��$��202,36,190,3q�$��36(�� $��1�� �� �� $
��1.5* �.+��� $��0��$��ID��$��232,42,0.4,26q�$��16(�$��Sylfaen)��� -   $	 txtboxSearch��$��1��$��9.6,41,179,27q��� -   $ btnSEARCH_Search��$��2��$��Search��$��242,9.8,269,27.8q��� -   $
 lblSearch_resualt��$��3��$�� ��$��161,9.8,171,31.4q��� -    $ TabSHOWCUSTOMERS��$y�	Collapsed=�.���  �� $
��.05* ��� .+�� $��0�� �� �� �� $
��.05* �.+��� $��0��$
��Name���� $��1��$
��Info��� $��1��.+��� .���� ���� *	costumers+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� .R��  �� �� .+��� $��0������ *Info1+�� $��1������ *Info2+�� -!   $ TabCHANGEPASS��$y�	Collapsed=�.���  �� �� �� �� �� �� .+��� -"   $
 lblPassword_LastTime��$��0��$��191,21,197,25q�� $��1�� �� �� $
��1.5* �.+��� $��0��$��Password��$��163,26,27.4,24.8q��� -#   $	 txtboxChangepass_Password��$��1��$��24.6,23,202,27.8q�� $��2�� �� �� $
��1.5* �.+��� $��0��$��New Password��$��148,26,27.4,24.8q��� -$   $	 txtboxChangepass_NewPass��$��1��$��24.6,23,202,27.8q�� $��3�� �� �� $
��1.5* �.+��� $��0��$B��<Confirm New Password                                        ��$��121,26,10.4,25q��� -%   $"	 txtboxChangepass_Confirmpass��$��1��$��24.6,23,202,27.8q�� $��4��.+��  �� �� .+��� -&   $ btnChangePass_Submit��$��0��$��Submit��$��157,16,31,16.8q��� -'   $ btnChangePass_Clear��$��1��$��Clear��$��10,16,176,16.8q��� -(   $
 lblPass_NowTime��$��5��$��146,21.6,151,23.4q�