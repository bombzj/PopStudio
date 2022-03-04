using System.Collections.ObjectModel;
using PopStudio.MAUI.Languages;

namespace PopStudio.MAUI;

public partial class Page_Setting : ContentPage
{
	public Page_Setting()
	{
		InitializeComponent();
		Title = MAUIStr.Obj.Setting_Title;
		label_introduction.Text = MAUIStr.Obj.Setting_Introduction;
		label_itemlanguage.Text = string.Format(MAUIStr.Obj.Setting_ItemLanguage, Setting.LanguageName[Setting.AppLanguage]);
		button_chooselanguage.Text = MAUIStr.Obj.Setting_SetLanguage;
		label_itemdz.Text = MAUIStr.Obj.Setting_ItemDz;
		label_introdz.Text = MAUIStr.Obj.Setting_IntroDz;
		button_dz_1.Text = MAUIStr.Obj.Setting_Add;
		button_dz_2.Text = MAUIStr.Obj.Setting_Clear;
		label_itempak.Text = MAUIStr.Obj.Setting_ItemPak;
		label_intropak.Text = MAUIStr.Obj.Setting_IntroPak;
		button_pak_1.Text = MAUIStr.Obj.Setting_Add;
		button_pak_2.Text = MAUIStr.Obj.Setting_Clear;
		label_itemrsb.Text = MAUIStr.Obj.Setting_ItemRsb;
		label_introrsb.Text = MAUIStr.Obj.Setting_IntroRsb;
		label_itemptx.Text = MAUIStr.Obj.Setting_ItemPtx;
		label_introptx.Text = MAUIStr.Obj.Setting_IntroPtx;
		label_itemcdat.Text = MAUIStr.Obj.Setting_ItemCdat;
		label_introcdat.Text = MAUIStr.Obj.Setting_IntroCdat;
		label_itemrton.Text = MAUIStr.Obj.Setting_ItemRTON;
		label_introrton.Text = MAUIStr.Obj.Setting_IntroRTON;
		label_itemcompiled.Text = MAUIStr.Obj.Setting_ItemCompiled;
		label_introcompiled.Text = MAUIStr.Obj.Setting_IntroCompiled;
		button_compiled_1.Text = MAUIStr.Obj.Setting_Load;
		button_compiled_2.Text = MAUIStr.Obj.Setting_Unload;
		button_recover.Text = MAUIStr.Obj.Setting_Recover;
		Setting_Dz.ItemsSource = dzpackinfo;
		Setting_PakPS3.ItemsSource = pakps3packinfo;
		
		InitDzPackSetting();
		InitPakPS3PackSetting();
		InitRsbPackSetting();
		InitPTXDecodeSetting();
		InitCdatKeySetting();
		InitRTONKeySetting();
		InitImageStringSetting();
	}

	/// <summary>
	/// DZ Setting Begin
	/// </summary>
	ObservableCollection<ListInfo> dzpackinfo = new ObservableCollection<ListInfo>();
	public ObservableCollection<ListInfo> DzPackInfo => dzpackinfo;

	private void Button_Dz_1_Clicked(object sender, EventArgs e)
	{
		AddDzPackSetting();
	}

	private void Button_Dz_2_Clicked(object sender, EventArgs e)
	{
		ClearDzPackSetting();
	}

	private void Setting_Dz_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.Count == 0) return;
		ChangeDzPackSetting((e.CurrentSelection.First() as ListInfo)?.ItemName);
		(sender as CollectionView).SelectedItem = null;
	}

	void InitDzPackSetting()
    {
		dzpackinfo.Clear();
		Dictionary<string, P_Package.Dz.CompressFlags> dzpacksetting = Setting.DzCompressDictionary;
		Dictionary<P_Package.Dz.CompressFlags, string> dzcompressname = Setting.DzCompressMethodName;
		dzpackinfo.Add(new ListInfo("default", dzcompressname[Setting.DzDefaultCompressMethod]));
		foreach (KeyValuePair<string, P_Package.Dz.CompressFlags> keyValuePair in dzpacksetting)
        {
			dzpackinfo.Add(new ListInfo(keyValuePair.Key, dzcompressname[keyValuePair.Value]));
		}
	}

	async void AddDzPackSetting()
    {
		try
		{
			string cancel = MAUIStr.Obj.Setting_Cancel;
			string ok = MAUIStr.Obj.Setting_OK;
			string ans = await DisplayPromptAsync(MAUIStr.Obj.Setting_EnterExtension, MAUIStr.Obj.Setting_EnterExtensionText, ok, cancel);
			if (!string.IsNullOrEmpty(ans))
			{
				string itemname = ans;
				if (!itemname.StartsWith('.'))
                {
					itemname = '.' + itemname;
				}
				string item1 = "Store";
				string item2 = "Lzma";
				string item3 = "Gzip";
				string item4 = "Bzip2";
				ans = await DisplayActionSheet(MAUIStr.Obj.Setting_ChooseCompressMode, cancel, ok, item1, item2, item3, item4);
				if (ans != cancel && ans != ok)
				{
					Dictionary<string, P_Package.Dz.CompressFlags> tempdic = Setting.DzCompressDictionary;
					if (tempdic.ContainsKey(itemname))
					{
						tempdic[itemname] = Setting.DzCompressMethodEnum[ans];
					}
                    else
                    {
						tempdic.Add(itemname, Setting.DzCompressMethodEnum[ans]);
					}
					InitDzPackSetting();
					Setting.SaveAsXml(Permission.GetSettingPath());
				}
			}
		}
		catch (Exception)
		{

		}
	}

	void ClearDzPackSetting()
    {
		Setting.DzCompressDictionary.Clear();
		InitDzPackSetting();
		Setting.SaveAsXml(Permission.GetSettingPath());
	}

	async void ChangeDzPackSetting(string itemname)
    {
        try
        {
			string cancel = MAUIStr.Obj.Setting_Cancel;
			string ok = MAUIStr.Obj.Setting_OK;
			string choose1 = MAUIStr.Obj.Setting_CompressItem1;
			string choose2 = MAUIStr.Obj.Setting_CompressItem2;
			string ans;
			if (itemname == "default")
            {
				ans = await DisplayActionSheet(MAUIStr.Obj.Setting_ChooseItem, cancel, ok, choose1);
			}
            else
            {
				ans = await DisplayActionSheet(MAUIStr.Obj.Setting_ChooseItem, cancel, ok, choose1, choose2);
			}
			if (ans == choose1)
			{
				string item1 = "Store";
				string item2 = "Lzma";
				string item3 = "Gzip";
				string item4 = "Bzip2";
				ans = await DisplayActionSheet(MAUIStr.Obj.Setting_ChooseCompressMode, cancel, ok, item1, item2, item3, item4);
				if (ans != cancel && ans != ok)
                {
					if (itemname == "default")
                    {
						Setting.DzDefaultCompressMethod = Setting.DzCompressMethodEnum[ans];
					}
                    else
                    {
						Setting.DzCompressDictionary[itemname] = Setting.DzCompressMethodEnum[ans];
					}
					InitDzPackSetting();
					Setting.SaveAsXml(Permission.GetSettingPath());
				}
			}
			else if (ans == choose2)
            {
				if (Setting.DzCompressDictionary.ContainsKey(itemname))
				{
					Setting.DzCompressDictionary.Remove(itemname);
					InitDzPackSetting();
					Setting.SaveAsXml(Permission.GetSettingPath());
				}
			}
		}
		catch (Exception)
        {

        }
    }

	/// <summary>
	/// PakPS3 Setting Begin
	/// </summary>
	ObservableCollection<ListInfo> pakps3packinfo = new ObservableCollection<ListInfo>();
	public ObservableCollection<ListInfo> PakPS3PackInfo => pakps3packinfo;

	private void Button_PakPS3_1_Clicked(object sender, EventArgs e)
	{
		AddPakPS3PackSetting();
	}

	private void Button_PakPS3_2_Clicked(object sender, EventArgs e)
	{
		ClearPakPS3PackSetting();
	}

	private void Setting_PakPS3_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.Count == 0) return;
		ChangePakPS3PackSetting((e.CurrentSelection.First() as ListInfo)?.ItemName);
		(sender as CollectionView).SelectedItem = null;
	}

	void InitPakPS3PackSetting()
	{
		pakps3packinfo.Clear();
		Dictionary<string, P_Package.Pak.CompressFlags> pakps3packsetting = Setting.PakPS3CompressDictionary;
		Dictionary<P_Package.Pak.CompressFlags, string> pakps3compressname = Setting.PakPS3CompressMethodName;
		pakps3packinfo.Add(new ListInfo("default", pakps3compressname[Setting.PakPS3DefaultCompressMethod]));
		foreach (KeyValuePair<string, P_Package.Pak.CompressFlags> keyValuePair in pakps3packsetting)
		{
			pakps3packinfo.Add(new ListInfo(keyValuePair.Key, pakps3compressname[keyValuePair.Value]));
		}
	}

	async void AddPakPS3PackSetting()
	{
		try
		{
			string cancel = MAUIStr.Obj.Setting_Cancel;
			string ok = MAUIStr.Obj.Setting_OK;
			string ans = await DisplayPromptAsync(MAUIStr.Obj.Setting_EnterExtension, MAUIStr.Obj.Setting_EnterExtensionText, ok, cancel);
			if (!string.IsNullOrEmpty(ans))
			{
				string itemname = ans;
				if (!itemname.StartsWith('.'))
				{
					itemname = '.' + itemname;
				}
				string item1 = "Store";
				string item2 = "Zlib";
				ans = await DisplayActionSheet(MAUIStr.Obj.Setting_ChooseCompressMode, cancel, ok, item1, item2);
				if (ans != cancel && ans != ok)
				{
					Dictionary<string, P_Package.Pak.CompressFlags> tempdic = Setting.PakPS3CompressDictionary;
					if (tempdic.ContainsKey(itemname))
					{
						tempdic[itemname] = Setting.PakPS3CompressMethodEnum[ans];
					}
					else
					{
						tempdic.Add(itemname, Setting.PakPS3CompressMethodEnum[ans]);
					}
					InitPakPS3PackSetting();
					Setting.SaveAsXml(Permission.GetSettingPath());
				}
			}
		}
		catch (Exception)
		{

		}
	}

	void ClearPakPS3PackSetting()
	{
		Setting.PakPS3CompressDictionary.Clear();
		InitPakPS3PackSetting();
		Setting.SaveAsXml(Permission.GetSettingPath());
	}

	async void ChangePakPS3PackSetting(string itemname)
	{
		try
		{
			string cancel = MAUIStr.Obj.Setting_Cancel;
			string ok = MAUIStr.Obj.Setting_OK;
			string choose1 = MAUIStr.Obj.Setting_CompressItem1;
			string choose2 = MAUIStr.Obj.Setting_CompressItem2;
			string ans;
			if (itemname == "default")
			{
				ans = await DisplayActionSheet(MAUIStr.Obj.Setting_ChooseItem, cancel, ok, choose1);
			}
			else
			{
				ans = await DisplayActionSheet(MAUIStr.Obj.Setting_ChooseItem, cancel, ok, choose1, choose2);
			}
			if (ans == choose1)
			{
				string item1 = "Store";
				string item2 = "Zlib";
				ans = await DisplayActionSheet(MAUIStr.Obj.Setting_ChooseCompressMode, cancel, ok, item1, item2);
				if (ans != cancel && ans != ok)
				{
					if (itemname == "default")
					{
						Setting.PakPS3DefaultCompressMethod = Setting.PakPS3CompressMethodEnum[ans];
					}
					else
					{
						Setting.PakPS3CompressDictionary[itemname] = Setting.PakPS3CompressMethodEnum[ans];
					}
					InitPakPS3PackSetting();
					Setting.SaveAsXml(Permission.GetSettingPath());
				}
			}
			else if (ans == choose2)
			{
				if (Setting.PakPS3CompressDictionary.ContainsKey(itemname))
				{
					Setting.PakPS3CompressDictionary.Remove(itemname);
					InitPakPS3PackSetting();
					Setting.SaveAsXml(Permission.GetSettingPath());
				}
			}
		}
		catch (Exception)
		{

		}
	}

	/// <summary>
	/// RsbPTX Setting Begin
	/// </summary>
	void InitRsbPackSetting()
    {
		rsbptx1.IsToggled = Setting.RsbPtxABGR8888Mode;
		rsbptx2.IsToggled = Setting.RsbPtxARGB8888PaddingMode;
	}

	private void Switch_RsbPtx_1_Toggled(object sender, ToggledEventArgs e)
	{
		Setting.RsbPtxABGR8888Mode = e.Value;
		Setting.SaveAsXml(Permission.GetSettingPath());
	}

	private void Switch_RsbPtx_2_Toggled(object sender, ToggledEventArgs e)
	{
		Setting.RsbPtxARGB8888PaddingMode = e.Value;
		Setting.SaveAsXml(Permission.GetSettingPath());
	}

	/// <summary>
	/// PTX Setting Begin
	/// </summary>
	void InitPTXDecodeSetting()
	{
		ptx.IsToggled = Setting.PtxABGR8888Mode;
	}

	private void Switch_Ptx_1_Toggled(object sender, ToggledEventArgs e)
	{
		Setting.PtxABGR8888Mode = e.Value;
		Setting.SaveAsXml(Permission.GetSettingPath());
	}

	/// <summary>
	/// Cdat Setting Begin
	/// </summary>
	void InitCdatKeySetting()
	{
		cdat.Text = Setting.CdatKey;
	}
	
	private void Entry_CdatKey_TextChanged(object sender, TextChangedEventArgs e)
	{
		Setting.CdatKey = e.NewTextValue;
		Setting.SaveAsXml(Permission.GetSettingPath());
	}

	/// <summary>
	/// RTON Setting Begin
	/// </summary>
	void InitRTONKeySetting()
	{
		rton.Text = Setting.RTONKey;
	}

	private void Entry_RTONKey_TextChanged(object sender, TextChangedEventArgs e)
	{
		Setting.RTONKey = e.NewTextValue;
		Setting.SaveAsXml(Permission.GetSettingPath());
	}

	/// <summary>
	/// ImageString Setting Begin
	/// </summary>
	void InitImageStringSetting()
	{
		imagestring.Text = Setting.ImageConvertName;
	}

	private async void Button_ImageString_1_Clicked(object sender, EventArgs e)
	{
        try
        {
			string path = await this.ChooseOpenFile();
			if (string.IsNullOrEmpty(path)) return;
			Setting.LoadImageConvertXml(path);
			InitImageStringSetting();
			Setting.SaveAsXml(Permission.GetSettingPath());
		}
		catch (Exception)
        {

        }
	}

	private void Button_ImageString_2_Clicked(object sender, EventArgs e)
	{
		Setting.ClearImageConvertXml();
		InitImageStringSetting();
		Setting.SaveAsXml(Permission.GetSettingPath());
	}

	private async void Button_ResetSetting_Clicked(object sender, EventArgs e)
	{
		string cancel = MAUIStr.Obj.Setting_Cancel;
		string ok = MAUIStr.Obj.Setting_OK;
		bool sure = await DisplayAlert(MAUIStr.Obj.Setting_SureRecover, MAUIStr.Obj.Setting_SureRecoverText, ok, cancel);
		if (sure)
        {
			Setting.ResetXml(Permission.GetSettingPath());
			await DisplayAlert(MAUIStr.Obj.Setting_FinishRecover, MAUIStr.Obj.Setting_FinishRecoverText, ok);
			Environment.Exit(0);
        }
	}

	public class ListInfo
    {
		public string ItemName { get; set; }
		public string ItemValue { get; set; }

        public ListInfo()
        {

        }

        public ListInfo(string itemName, string itemValue)
        {
            ItemName = itemName;
            ItemValue = itemValue;
        }
    }

	async void ChangeLanguageSetting()
	{
        try
        {
			string cancel = MAUIStr.Obj.Setting_Cancel;
			string ok = MAUIStr.Obj.Setting_OK;
			string item1 = "��������";
			string item2 = "English";
			string ans = await DisplayActionSheet(MAUIStr.Obj.Setting_ChooseLanguage, cancel, ok, item1, item2);
			if (ans != cancel && ans != ok && Setting.LanguageEnum[ans] != Setting.AppLanguage)
			{
				Setting.AppLanguage = Setting.LanguageEnum[ans];
				Setting.SaveAsXml(Permission.GetSettingPath());
				await DisplayAlert(MAUIStr.Obj.Setting_FinishChooseLanguage, MAUIStr.Obj.Setting_FinishChooseLanguageText, ok);
				Environment.Exit(0);
			}
		}
		catch (Exception)
        {

        }
	}

	private void button_chooselanguage_Clicked(object sender, EventArgs e)
    {
		ChangeLanguageSetting();
	}
}