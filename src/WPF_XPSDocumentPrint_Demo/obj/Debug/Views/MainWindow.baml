   M S B A M L   `   `   `  ����U  QPresentationUI, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35[>clr-namespace:System.Windows.Documents;assembly=PresentationUISystem.Windows.Documents  5       WPF_XPSDocumentPrint_Demo0   *WPF_XPSDocumentPrint_Demo.Views.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      S OPrism.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59Z VPrism.DryIoc.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      Iui>clr-namespace:System.Windows.Documents;assembly=PresentationUI   5      $
��1280��5      $	��800��5	      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�5
       � Title 5      �� *Title+ � 	Resources 5         DocumentViewerTemplate1 �� 
TargetType-  'System.Windows.Input.KeyboardNavigation   TabNavigation � ColumnDefinitions � RowDefinitions �� 
ResourceId �� TypeInTargetAssembly;   5System.Windows.Documents.PresentationUIStyleResources	 ��Name
 �� 
StartPoint �� EndPoint � Offset � Color ��Name��%=  &	        �� 5   
   " Z�6:   .R�5      �� #��z��5      #��z��5      |�.  ._�5      � #��z��6   $ Local=�6A    5      �� 5      $��* �6+    5      �� 5      $
��Auto �6(   �� 5      $��* �6(   �� 5      $
��Auto �6(   .+�5      �� $��0��5      $��0��5      #|�z|�5      $��0��5       ��5      C� *�� $&  PUIDocumentViewerToolBarStyleKey��"  +5       �� 5!      $	 PART_ContentHost��5"      $��1��5#      $��0��5$      ��. #|�z|�5&      $
��Auto=�5'      ��. $��1��5)      ]� 5*      $��1��6    .+�5+      � #��� r�6+   $��Right=�6{   �� 5,      $��10��5-      $	��top=�5.      $y�Visible=�5/      ��50      �� 51   "   $	
 0,0&�66   $	 0,1&�6G   ��53   *   � � 54   .   $ 0Q�6;   $ 	#66000000��6F   � 55   .   $ 1Q�6;   $ Transparent��6F   56   +   58   #   5:      5;      �� 5<      $ PART_FindToolBarHost��5=      $��2��5>      $��0��5?      #|�z|�5@      $��2��5A      5B      5C      5D      5E      .��5F      �  5G   
   �� 5H      $��* �6   �� 5I      $	��10* �6   .+�5K   
   ��  d� 	IsChecked$
 TrueY�68   $��Center=�6�   $��Center=�6�   $	��100��6�   $��20��6�   ��6   �� *ChangeDocCommand+��6I   �� *	IsChecked+ �� RelativeSource ��  �� Mode$
 Self=�6�   Z� 5L   
   $��1��5M        DocumentViewer#���  5O      #���   5P      ��5N      �� *StudentDocument+5P      5Q      5R      