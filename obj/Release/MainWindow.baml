   M S B A M L   `   `   `  ���� >  :HW6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HW6HW6      HW6.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     #localclr-namespace:HW6       � Title$  
MainWindow��$	��700��$	��500�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=� � 	Resources    FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 btnAboutUsstyle	 �� 
TargetType
 �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 N     &	 c     &	 x     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     7   7  7  7  7  7 	 �� .���  � �� �� .R��� $��2q� . #��� ��$��1��$	 1 2R��� $ 	#FFDDDDDD���� $ 	#FF707070���� $ 	#FFBEE6FD���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� "	 ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� "
 ��.R��� $ border��#��z��#��z��#��z�� . ._��� $ contentPresenter��|�.  #��z��#��z����. # z #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  � {� .  . ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8   � ��.��� ���� .+��� -    ��Name$ TabCtrlMain��.@��� -    ��Name$ 	TabWelcom��$y�	Collapsed=�.��� ����  �� ImageSource$ BG_main.jpg�� � ColumnDefinitions �� $��0* ���  � RowDefinitions �� $	��.2* ��� $
��1.5* ��� �� �� $	��.3* �.+��� -    ��Name$ btnExit��$��0��$��0q�$��20��$��20��$��Center=�$��Right=�$��1��$��	0,6,0,6.8q���Z� .���� $��	Power.png���� $��1��$�� Welcome to my shope��$��Center=�$��Center=�
���   �$��36(�$��Showcard Gothic)�$��1��$��29,135.2,48,66.2q�$��45��$	��411���� $��2��$'��! Choose wich part you want enter:��$��Center=�$��Center=�
���   �$��24(�$��Showcard Gothic)�$��1��$��10,1.8,10,133q�$��30��$	��468��� $��3��$��1��$��2��$��	0,0,0,0.4q� �� �� .+��� -   $ btnAdmin��$��0��$��37,-4,44.4,74.4q�$��50,20q�#��� 
 ��Z� ���� $ 
admin2.png���� -   $ btnUser��$��1��$	��Top=�$��45.6,0,41.8,0q�$��50,20q�$	��144��#��� 
 ��Z� ���� $ 	user2.png��� $��4��$��2��$��0,0.2,0,0.4q� �� $
��1.5* ��� .+��� $��0��$��Created by Arshia��$��Bottom=�$
��Left=����	#FF978A8A$��16(��� -   $ 
btnAboutUs��$��1��$��About us��$��0,0,0,1q�$��Bottom=�$��Right=�
���   �$��	0,0,3,2.6q�#��� 
 ��Z� �� -   $ TabUser��$y�	Collapsed=�.���  �� $
��.12* ��� $	��.5* ��� $��3* �.+��� -   $ btnUserBack��$��0��$��Bottom=�$
��Left=�$��
8,0,0,72.8q�$��37��$��2��$��36��#��� 
 ��Z� ���� $ left.png���� $��1��$��Choose your type:��$��Center=�$��Center=�$��36(�$��Stencil)����	#FF04590B� $��2�� �� �� �� .+��� -	   $ 
btnStudent��$��0��$��183,37,189,37.4q�$��40,20q�$	��108�� J� RenderTransformOrigin$ 0.5,0.5&�#��� 
 ��Z� ���� $ student.png���� -
   $ 
btnTeacher��$��183,21.6,189,57q�$��1��#��� 
 ��Z� ���� $ training-icon-green.png���� -   $ btnCoustumer��$��2��$��183,0,189,77.6q�$��40,20q�#��� 
 ��Z� ���� $ cotumer.png���� -   $ 	TabSignIn��$y�	Collapsed=�.��� ���� $ loginBackground.jpg�� �� $	��.2* ��� $��3* ��� �� �� �� .+��� -   $ btnBackSignIn��$��0��$��Bottom=�$
��Left=�$��10,0,0,247.8q�$��37��$��2��$��37��#��� 
 ��Z� ���� $ left.png���� $��1��$��Sign in��$��Center=�$��Center=�$��36(�$
��Bold"�$��Italic$�$��Showcard Gothic)���Z� �� $��2��$��Center=�$��Center=�$��50,10q�.+��� -    ��Name$ txtblkUserName��$��	Username:��$��16(�$
��Bold"�$��Italic$�$��Showcard Gothic)��� -    ��Name$ 
txtbxEmail��$��0,0,0,2q�
���   �$	��235����Z� �� -    ��Name$ lblEmailError��$��7q����	#FFDD1616�� $��3��$��Center=�$��Center=�$��50,10q�.+��� -   $ txtblkPassword��$��	Password:��$��16(�$
��Bold"�$��Showcard Gothic)��� -   $ txtbxPassword��$��0,0,0,2q�
���   �$	��235����Z� �� -   $ lblPasswordError��$��7q����	#FFDD1616
���   ��� -   $ btnLogin��$��4��$��Login��$��Center=�$��Center=�$��60,10q����	#FF16B467���	#FF020000$
��Bold"�$��Showcard Gothic)�$��16(�� $��5�� �� �� .+��� -    ��Name$ chkbxRemeberme��$��0��$��
Remeber Me��$	��Top=�$��Right=�$��	0,13,20,0q�$
��Bold"��� -   $ btnForgetPass��$��1��$��Forget Password?��$��0q�$	��Top=�$
��Left=�$��	20,11,0,0q�$
��Bold"���Z� 