   M S B A M L   `   `   `  ���� N  JBIM Leaders Windows, Version=1.1.5.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BIM_Leaders_WindowsBIM_Leaders_Windows  &     BIM_Leaders_Windows.EstimateForm   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:BIM_Leaders_Windows     _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -   "   BIM_Leaders_Windows.BaseView   Name$  EstimateWindow��"   BIM_Leaders_Windows.BaseView   MouseLeftButtonDown$ FormMouseMove�� � WindowStyle$
 None=�   SWindow#���    � Title$ BIM Leaders - Checker�� � WindowStartupLocation$ CenterScreen=�$	��810��$	��360�� � 	Resources  �� Source�� $ ../Resources.xaml?�%    .��� ��Z� .+�#  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 36Q�����  �� 
StartPoint$ 0.1, 0&�	 �� EndPoint$	 0.3, 1&�.��� 
 � Offset$
 1Q� � Color ��   SColorBackgroundMain1 �� Source# [  �� Path$ Color�� $
 0Q� ��   SColorBackgroundMain2# [ $ Color�.��� ��Z�  � RowDefinitions �� $��72 ��� $��* ��� $��72 �.+�� $��0��.+��� $��	Estimator��  
STextBlock#��[ �� -    ��Name$ buttonCancel��  SButtonClose#��[ ���� *CloseCommand+ �� Mode$ OneWay=�����  �� ElementName$ EstimateWindow��� $��1��.+��� $
��Left=�$	��Top=�$��	18,0,18,0q�  STabControl#��[ .@��� $��
 Annotate ��$��78��  STabItemLeft#��[ .��� $
��Left=�$	��Top=���Z�  � ColumnDefinitions �� $	��252 ��� $	��522 �.+�� $��0��.+��� $��0,9,18,0q�.+��� $��Stage��
������� 
 SLabel#��[ �� -    ��Name$ checkboxHagasha��$��Hagasha��
�������  	SCheckBox#��[  d� 	IsChecked �� $ Hagasha�$ TwoWay=��� -   $ checkboxHaga��$
��Haga��
�������
�������#��[  �� $
 Haga�$ TwoWay=��� -   $ checkboxMecher��$��Mecher��
�������#��[  �� $ Mecher�$ TwoWay=��� -   $ 
checkboxWP��$��Shop Drawings��
�������#��[  �� $ WP�$ TwoWay=��� -   $ checkboxCost��$��Cost Estimation��
�������
�������#��[  �� $
 Cost�$ TwoWay=�� $��1��.+��� $��	0,9,270,0q�.+��� $��Speed��
�������#��[ �� -   $ checkboxJunior��$��Junior��
�������
�������
�������#��[  �� $ Junior�$ TwoWay=��� -	   $ checkboxMiddle��$��Middle��
�������
�������#��[  �� $ Middle�$ TwoWay=��� -
   $ checkboxSenior��$��Senior��
�������#��[  �� $ Senior�$ TwoWay=�� $��2��.+��� $��
270,9,18,0q�.+��� $
��View��
�������#��[ �� -   $ checkboxCurrentView��$��Current View��
�������#��[  �� $ CurrentView�$ TwoWay=��� -   $ checkboxWholeModel��$��Whole Model��
�������#��[  �� $ 
WholeModel�$ TwoWay=��� $�� Model ��$��78�� 	 STabItemCenter#��[	 .��� $
��Left=�$	��Top=���Z�  �� $	��270 ��� $��* �.+�� $��0��.+��� $
��Left=�$	��Top=�$��0,9,0,0q�$	��220��.+��� $��Speed��
�������#��[ �� -   $ checkboxJuniorModel��$��Junior��
�������
�������
�������#��[  �� $ Junior�$ TwoWay=��� -   $ checkboxMiddleModel��$��Middle��
�������
�������#��[  �� $ Middle�$ TwoWay=��� -   $ checkboxSeniorModel��$��Senior��
�������#��[  �� $ Senior�$ TwoWay=��� $��Level of Detail��
�������#��[ �� -   $ checkboxCoarse��$��Coarse��
�������
�������
�������#��[  �� $ Coarse�$ TwoWay=��� -   $ checkboxMedium��$��Medium��
�������
�������#��[  �� $ Medium�$ TwoWay=��� -   $ checkboxFine��$
��Fine��
�������#��[  �� $
 Fine�$ TwoWay=�� $��1��$	��220��.+��� $��0,9,0,0q�.+��� $ ��Gross Buidling Area (sqm.)��
�������#��[ �� -    ��Name$ textBlockArea��
������� 
 STextBox#��[
 ���� *	GrossArea+ �� UpdateSourceTrigger$ PropertyChanged=��� $��Number of Floors��
�������#��[ �� -   $ textBlockFloors��
�������#��[
 ���� *FloorsNumber+$ PropertyChanged=��� $��Number of Typical Floors��
�������#��[ �� -   $ textBlockTypicalFloors��
�������#��[
 ���� *NumberTypicalFloors+$ PropertyChanged=�� $��2��.+��� -   $ buttonOk��$��Magic�� � ToolTip$	 Run��$	��234��  	SButtonOk#��[ ���� *
RunCommand+���� $ EstimateWindow��{�`�   MultivalueBoolInvert `� 	Converter# [  `� Mode$ TwoWay=�.1��� $ textboxPrefix��$ (Validation.HasError)�$ PropertyChanged=�$ OneWay=��� $ textboxHeight��$ (Validation.HasError)�$ PropertyChanged=�$ OneWay=�