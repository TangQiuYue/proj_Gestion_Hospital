   M S B A M L   `   `   `  ����P  Lproj_Gestion_Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:proj_Gestion_Hospitalproj_Gestion_Hospital  5   	   '    !proj_Gestion_Hospital.AdminWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:proj_Gestion_Hospital     5   	     � Title$  AdminWindow��5   	   $	��500��6   $	��600��6*   .��5	      � ��5
   
   �� 5       �� ImageSource$� �C:\Users\TQY_06\Desktop\Graphics\Course_Code\Project_Integrateur_Bourassa_ME\Project_Integrateur_Bourassa_ME\bin\Debug\Images\northern_lights.png��6    j� Stretch$ UniformToFill=�6�    �� Opacity$	 0.5Q�6�   .+�5   
   o� -   5         o�Name$
 menu��5      $
��Left=�6   $��26��68   $	��Top=�6D   $	��582��6\   .@�5      m� $��Administrer��6   $��70��6,   .@�5      m� -   5         m�Name$ addDoc��5      $��_Add Doctors��6+   6A   m� 5      -   5        $ modifDoc��5      $��_Modify Doctors��6-   6F   m� 5      -   5        $ 	deleteDoc��5      $��_Delete Doctor��6.   6F   5      m� 5      $��	Consulter��6   .@�5      m� -   5        $ 
doctorList��5      $��_List of Doctors��6/   6I   5      5      � 5   
   -   5         �Name$ consultForm��5      $
��Left=�6$   $	��428��6?   $��	75,26,0,0q�6L   $	��Top=�6_   $	��517��6w   $y�Hidden=�6�   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ doctorsdataGrid��5      $
��Left=�60   $��	62,55,0,0q�6K   $	��Top=�6^   $	��181��6v   $	��416��6�   5      � 5   
   -   5        $ 
addDocForm��5      $
��Left=�6#   $	��220��6>   $��	40,40,0,0q�6K   $	��Top=�6^   $	��255��6v   $y�Hidden=�6�   .+�5      �� -	   5         ��Name$ nomLbl��5      $	��Nom��6$   $
��Left=�62   $��	10,45,0,0q�6M   $	��Top=�6`   �� 5      -
   5        $ 	prenomLbl��5      $��Prenom��6'   $
��Left=�68   $��	10,80,0,0q�6S   $	��Top=�6f   �� 5      -   5        $ specialiteLbl��5      $��
Specialite��6+   $
��Left=�6@   $��
10,119,0,0q�6[   $	��Top=�6o   �� 5       -   5        	 ��Name$	 	nomTxtBox��5       $
��Left=�6)   $��23��6D   $��	76,45,0,0q�6P   
 �� TextWrapping$

 Wrap=�6c   $�� ��6w   $	��Top=�6�   $	��120��6�   $��1��6�   �� 5!      -   5        $	 specialiteTxtBox��5!      $
��Left=�60   $��23��6K   $��
76,119,0,0q�6W   $

 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��120��6�   $��3��6�   �� 5"      -   5        $	 prenomTxtBox��5"      $
��Left=�6,   $��23��6G   $��	76,80,0,0q�6S   $

 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   $��2��6�   � 5#      $
��Left=�6   $	��100��6.   $��10,0,0,0q�6;   $	��Top=�6M   $	��100��6e   �� 5$      -   5         ��Name$ 
ajouterBtn��5$      $��4��6)   $��Ajouter��66   $
��Left=�6H   $��121,169,0,0q�6c   $	��Top=�6x   $��75��6�   6�   5%      � 5&   
   -   5        $ 	modifForm��5&      $
��Left=�6"   $	��276��6=   $��	40,79,0,0q�6J   $	��Top=�6]   $	��346��6u   $y�Hidden=�6�   .+�5'      �� -   5         ��Name$ doctorListCmb��5'      $��5��6.   $
��Left=�6<   $��
76,0,0,247q�6W   $	��119��6k   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6w    �� DisplayMemberPath$ 
ID_medecin��6�   ��6�   �� 6�   �� 5(      -   5        $ 	nomModLbl��5(      $	��Nom��6'   $
��Left=�65   $��	10,45,0,0q�6P   $	��Top=�6c   �� 5)      -   5        $ prenomModLbl��5)      $��Prenom��6*   $
��Left=�6;   $��	10,80,0,0q�6V   $	��Top=�6i   �� 5*      -   5        $ specialiteModLbl��5*      $��
Specialite��6.   $
��Left=�6C   $��
10,119,0,0q�6^   $	��Top=�6r   �� 5+      -   5        $	 nomModTxtBox��5+      $��7��6,   $
��Left=�69   $��23��6T   $��	76,45,0,0q�6`   $

 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5,      -   5        $	 specialiteModTxtBox��5,      $��9��63   $
��Left=�6@   $��23��6[   $��
76,119,0,0q�6g   $

 Wrap=�6{   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5-      -   5        $	 prenommodTxtBox��5-      $��8��6/   $
��Left=�6<   $��23��6W   $��	76,80,0,0q�6c   $

 Wrap=�6v   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5.      -   5        $ modifierBtn��5.      $��10��6*   $��Modifier��68   $
��Left=�6K   $��153,226,0,0q�6f   $	��Top=�6{   $��75��6�   $y�Hidden=�6�   �� 5/      -   5        $ idDocModLBL��5/      $��
ID Medecin��6)   $
��Left=�6>   $��10,2,0,0q�6Y   $	��Top=�6k    J� RenderTransformOrigin$ 0.413,-0.272&�6�   �� 50      -   5        $ goBtn��50      $
��Find��6$   $��6��63   $
��Left=�6@   $��	221,8,0,0q�6[   $	��Top=�6n   $��75��6�   6�   �� 51      -   5        $ 	deleteBtn��51      $��10��6(   $��Delete��66   $
��Left=�6G   $��233,226,0,0q�6b   $	��Top=�6w   $��75��6�   $y�Hidden=�6�   52      53      54      