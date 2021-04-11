using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GroanUI.Util;
using SharpNoise;
using SharpNoise.Modules;

namespace GroanUI.Views.Main
{
    public partial class MainForm : Form, IMainView
    {
        private readonly MainPresenter _presenter;

        public MainForm(MainPresenter presenter)
        {
            _presenter = presenter;
            InitializeComponent();
            _presenter.SetView(this);

            // Create some indexes of controls for ease of use later
            IndexConfigTabs();
            IndexDecimalSliders();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _presenter.Init();
            _noiseTypesListItemIndex = IndexListItem<NoiseType>(NoiseTypeComboBox.Items);
            _perlinQualitiesListItemIndex = IndexListItem<NoiseQuality>(PerlinQuality.Items);
            _billowQualitiesListItemIndex = IndexListItem<NoiseQuality>(BillowQuality.Items);
            _cellTypesListItemIndex = IndexListItem<Cell.CellType>(CellTypeComboBox.Items);
        }

        #region View implementation

        public string ViewTitle { set => Text = value; }

        public Size MapSize { set => NoiseMapPreview.Size = value; }

        public Bitmap NoiseMapImage { set => NoiseMapPreview.Image = value; }
        public IEnumerable<ListItem<Cell.CellType, string>> CellTypes
        {
            set
            {
                var data = value.ToArray();
                if (!Equals(CellTypeComboBox.DataSource, data))
                {
                    CellTypeComboBox.DataSource = data;
                }
                CellTypeComboBox.DisplayMember = nameof(ListItem<Cell.CellType, string>.Value);
            }
        }
        public Cell.CellType SelectedCellType
        {
            set =>
                CellTypeComboBox.SelectedItem =
                    _cellTypesListItemIndex.TryGetValue(value, out var item)
                        ? item
                        : CellTypeComboBox.Items[0];
        }


        public IEnumerable<ListItem<NoiseType, string>> NoiseTypes
        {
            set
            {
                if (!Equals(NoiseTypeComboBox.DataSource, value))
                {
                    NoiseTypeComboBox.DataSource = value;
                }
                NoiseTypeComboBox.DisplayMember = nameof(ListItem<NoiseType, string>.Value);
            }
        }
        public NoiseType SelectedNoise
        {
            set =>
                NoiseTypeComboBox.SelectedItem =
                    _noiseTypesListItemIndex.TryGetValue(value, out var item)
                        ? item
                        : NoiseTypeComboBox.Items[0];
        }

        public IEnumerable<ListItem<NoiseQuality, string>> NoiseQualities
        {
            set
            {
                if (!Equals(PerlinQuality.DataSource, value))
                {
                    PerlinQuality.DataSource = value.ToList();
                }
                PerlinQuality.DisplayMember = nameof(ListItem<NoiseType, string>.Value);

                if (!Equals(BillowQuality.DataSource, value))
                {
                    BillowQuality.DataSource = value.ToList();
                }
                BillowQuality.DisplayMember = nameof(ListItem<NoiseType, string>.Value);
            }
        }
        public NoiseQuality SelectedPerlinQuality
        {
            set =>
                PerlinQuality.SelectedItem =
                    _perlinQualitiesListItemIndex.TryGetValue(value, out var item)
                        ? item
                        : PerlinQuality.Items[0];
        }

        public NoiseQuality SelectedBillowQuality
        {
            set =>
                BillowQuality.SelectedItem =
                    _billowQualitiesListItemIndex.TryGetValue(value, out var item)
                        ? item
                        : BillowQuality.Items[0];
        }

        public bool GenerateGrayscale { set => Grayscale.Checked = value; }
        public bool Inverted { set => Invert.Checked = value; }
        public bool Rounded { set => Round.Checked = value; }

        public void ShowDefaultOptionsTab()
        {
            optionTabControl.SelectedTab = optionTabControl.TabPages[0];
            NoiseTypeComboBox.SelectedIndex = 0;
        }

        public void ShowOptionsTabFor(NoiseType noiseType) =>
            optionTabControl.SelectedTab = 
                _configTabsIndex.TryGetValue(noiseType, out var tab) 
                    ? tab 
                    : optionTabControl.TabPages[0];



        public void DisableChangeEvents()
        {
            NoiseTypeComboBox.SelectedIndexChanged -= NoiseTypeComboBox_SelectedIndexChanged;
            optionTabControl.SelectedIndexChanged -= OptionTabControl_SelectedIndexChanged;
            PerlinQuality.SelectedIndexChanged -= PerlinQuality_SelectedIndexChanged;
            BillowQuality.SelectedIndexChanged -= BillowQuality_SelectedIndexChanged;
            CellTypeComboBox.SelectedIndexChanged -= CellTypeComboBox_SelectedIndexChanged;
        }

        public void EnableChangeEvents()
        {
            NoiseTypeComboBox.SelectedIndexChanged += NoiseTypeComboBox_SelectedIndexChanged;
            optionTabControl.SelectedIndexChanged += OptionTabControl_SelectedIndexChanged;
            PerlinQuality.SelectedIndexChanged += PerlinQuality_SelectedIndexChanged;
            BillowQuality.SelectedIndexChanged += BillowQuality_SelectedIndexChanged;
            CellTypeComboBox.SelectedIndexChanged += CellTypeComboBox_SelectedIndexChanged;
        }

        public void SetupSliders(params DecimalSlider.Configuration[] sliderSetup)
        {
            foreach (var setup in sliderSetup)
            {
                if (_sliderControls.TryGetValue(setup.Slider, out var c))
                {
                    var slider = (DecimalSlider)c;
                    slider.Setup(setup);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

        }

        #endregion

        #region Control events
        private void NoiseTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
            => _presenter.SelectNoiseType(NoiseTypeComboBox.SelectedItem.AsListItem<NoiseType>().ID);

        private void CellTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
            => _presenter.SelectCellType((CellTypeComboBox.SelectedItem.AsListItem<Cell.CellType>()).ID);

        private void OptionTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = ((TabControl)sender).SelectedTab;

            if (tab?.Tag == null)
            {
                _presenter.SelectDefaultNoise();
            }
            else
            {
                foreach (var t in tab.Tag.ToString()!.Split(",", StringSplitOptions.TrimEntries))
                {
                    if (Enum.TryParse<NoiseType>(t, out var nt))
                    {
                        _presenter.SelectOptionsTab(nt);
                        break;
                    }
                }
            }
        }

        private void PerlinFrequency_Scroll(object sender, EventArgs e)
            => _presenter.UpdatePerlinFrequency(sender.AsDecimalSlider().Value);
        private void PerlinLacunarity_Scroll(object sender, EventArgs e)
            => _presenter.UpdatePerlinLacunarity((sender.AsDecimalSlider()).Value);
        private void PerlinPersistance_Scroll(object sender, EventArgs e)
            => _presenter.UpdatePerlinPersistance(sender.AsDecimalSlider().Value);
        private void PerlinOctaves_Scroll(object sender, EventArgs e)
            => _presenter.UpdatePerlinOctaves((int)sender.AsDecimalSlider().Value);
        private void PerlinQuality_SelectedIndexChanged(object sender, EventArgs e)
            => _presenter.SelectPerlinQuality(PerlinQuality.SelectedItem.AsListItem<NoiseQuality>().ID);

        private void BillowFrequency_Scroll(object sender, EventArgs e)
            => _presenter.UpdateBillowFrequency(sender.AsDecimalSlider().Value);
        private void BillowLacunarity_Scroll(object sender, EventArgs e)
            => _presenter.UpdateBillowLacunarity(sender.AsDecimalSlider().Value);
        private void BillowPersistance_Scroll(object sender, EventArgs e)
            => _presenter.UpdateBillowPersistance(sender.AsDecimalSlider().Value);
        private void BillowOctaves_Scroll(object sender, EventArgs e)
            => _presenter.UpdateBillowOctaves((int)sender.AsDecimalSlider().Value);
        private void BillowQuality_SelectedIndexChanged(object sender, EventArgs e)
            => _presenter.SelectBillowQuality(BillowQuality.AsListItem<NoiseQuality>().ID);

        private void CylinderFrequency_Scroll(object sender, EventArgs e)
            => _presenter.UpdateCylinderFrequency(sender.AsDecimalSlider().Value);

        private void CellFrequency_Scroll(object sender, EventArgs e)
            => _presenter.UpdateCellFrequency(sender.AsDecimalSlider().Value);
        private void CellDisplacement_Scroll(object sender, EventArgs e)
            => _presenter.UpdateCellDisplacement(sender.AsDecimalSlider().Value);
        private void CellEnable_CheckedChanged(object sender, EventArgs e)
            => _presenter.SetCellEnableDistance(sender.AsCheckBox().Checked);

        private void NoiseScale_Scroll(object sender, EventArgs e)
            => _presenter.UpdateScale(sender.AsDecimalSlider().Value);
        private void Grayscale_CheckedChanged(object sender, EventArgs e)
            => _presenter.SetGrayscale(sender.AsCheckBox().Checked);
        private void Invert_CheckedChanged(object sender, EventArgs e)
            => _presenter.SetInverted(sender.AsCheckBox().Checked);
        private void RoundCheckBox_CheckedChanged(object sender, EventArgs e)
            => _presenter.SetRounded(sender.AsCheckBox().Checked);
        private void MinValue_Scroll(object sender, EventArgs e)
            => _presenter.UpdateMinValue(sender.AsDecimalSlider().Value);
        private void MaxValue_Scroll(object sender, EventArgs e)
            => _presenter.UpdateMaxValue(sender.AsDecimalSlider().Value);

        private void NoiseMapPreview_Click(object sender, EventArgs e) 
            => _presenter.SetNewSeed();

        #endregion

        #region Control indexes

        private SliderIndex _sliderControls;
        private void IndexDecimalSliders()
        {
            _sliderControls = new()
            {
                { Sliders.PerlinFrequency, PerlinFrequency },
                { Sliders.PerlinLacunarity, PerlinLacunarity },
                { Sliders.PerlinPersistance, PerlinPersistance },
                { Sliders.PerlinOctaves, PerlinOctaves },
                { Sliders.BillowFrequency, BillowFrequency },
                { Sliders.BillowLacunarity, BillowLacunarity },
                { Sliders.BillowPersistance, BillowPersistance },
                { Sliders.BillowOctaves, BillowOctaves },
                { Sliders.MinValue, MinValue },
                { Sliders.MaxValue, MaxValue },
                { Sliders.Scale, NoiseScale },
                { Sliders.CylinderFrequency, CylinderFrequency },
                { Sliders.CellFrequency, CellFrequency},
                { Sliders.CellDisplacement, CellDisplacement},
            };
        }
        
        private readonly TabPageIndex _configTabsIndex = new();
        private void IndexConfigTabs()
        {
            foreach (TabPage tab in optionTabControl.TabPages)
            {
                if (tab?.Tag == null) continue;

                foreach (var t in tab.Tag.ToString()!.Split(",", StringSplitOptions.TrimEntries))
                {
                    if (Enum.TryParse<NoiseType>(t, out var nt))
                    {
                        _configTabsIndex.Add(nt, tab);
                    }
                }
            }
        }

        private ListItemIndex<NoiseType> _noiseTypesListItemIndex;
        private ListItemIndex<NoiseQuality> _perlinQualitiesListItemIndex;
        private ListItemIndex<NoiseQuality> _billowQualitiesListItemIndex;
        private ListItemIndex<Cell.CellType> _cellTypesListItemIndex;
        
        private ListItemIndex<T> IndexListItem<T>(ComboBox.ObjectCollection objectCollection)
        {
            var r = new ListItemIndex<T>();

            foreach (ListItem<T, string> listItem in objectCollection)
            {
                r.Add(listItem.ID, listItem);
            }

            return r;
        }

        private class ListItemIndex<T> : Dictionary<T, ListItem<T, string>>
        {

        }

        private class SliderIndex : Dictionary<Sliders, Control>
        {

        }

        private class TabPageIndex : Dictionary<NoiseType, TabPage> { }
        #endregion

    }
    static class Ext
    {
        public static DecimalSlider AsDecimalSlider(this object ctrl) => ctrl as DecimalSlider;
        public static CheckBox AsCheckBox(this object ctrl) => ctrl as CheckBox;
        public static ListItem<T, string> AsListItem<T>(this object ctrl) => ctrl as ListItem<T, string>;
    }
}
