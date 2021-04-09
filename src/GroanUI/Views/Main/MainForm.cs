using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            _noiseTypesListItemIndex = IndexListItem<NoiseType>(NoiseTypeComboBox.Items);
            _perlinQualitiesListItemIndex = IndexListItem<NoiseQuality>(PerlinQuality.Items);
            _billowQualitiesListItemIndex = IndexListItem<NoiseQuality>(BillowQuality.Items);
            _cellTypesListItemIndex = IndexListItem<Cell.CellType>(CellTypeComboBox.Items);

            _presenter.Init();
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
        }

        public void EnableChangeEvents()
        {
            NoiseTypeComboBox.SelectedIndexChanged += NoiseTypeComboBox_SelectedIndexChanged;
            optionTabControl.SelectedIndexChanged += OptionTabControl_SelectedIndexChanged;
            PerlinQuality.SelectedIndexChanged += PerlinQuality_SelectedIndexChanged;
            BillowQuality.SelectedIndexChanged += BillowQuality_SelectedIndexChanged;
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
            => _presenter.SelectNoiseType(((ListItem<NoiseType, string>)NoiseTypeComboBox.SelectedItem).ID);

        private void CellTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
            => _presenter.SelectCellType(((ListItem<Cell.CellType, string>)CellTypeComboBox.SelectedItem).ID);

        private void PerlinQuality_SelectedIndexChanged(object sender, EventArgs e)
            => _presenter.SelectPerlinQuality(((ListItem<NoiseQuality, string>)PerlinQuality.SelectedItem).ID);

        private void BillowQuality_SelectedIndexChanged(object sender, EventArgs e)
            => _presenter.SelectBillowQuality(((ListItem<NoiseQuality, string>)BillowQuality.SelectedItem).ID);

        private void OptionTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = ((TabControl) sender).SelectedTab;

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
            => _presenter.UpdatePerlinFrequency(((DecimalSlider) sender).Value);

        private void PerlinLacunarity_Scroll(object sender, EventArgs e) 
            => _presenter.UpdatePerlinLacunarity(((DecimalSlider) sender).Value);

        private void PerlinPersistance_Scroll(object sender, EventArgs e)
            => _presenter.UpdatePerlinPersistance(((DecimalSlider) sender).Value);

        private void PerlinOctaves_Scroll(object sender, EventArgs e)
            => _presenter.UpdatePerlinOctaves((int)((DecimalSlider) sender).Value);

        private void BillowFrequency_Scroll(object sender, EventArgs e)
            => _presenter.UpdateBillowFrequency(((DecimalSlider)sender).Value);

        private void BillowLacunarity_Scroll(object sender, EventArgs e)
            => _presenter.UpdateBillowLacunarity(((DecimalSlider)sender).Value);

        private void BillowPersistance_Scroll(object sender, EventArgs e)
            => _presenter.UpdateBillowPersistance(((DecimalSlider)sender).Value);

        private void BillowOctaves_Scroll(object sender, EventArgs e)
            => _presenter.UpdateBillowOctaves((int)((DecimalSlider)sender).Value);


        private void CylinderFrequency_Scroll(object sender, EventArgs e)
            => _presenter.UpdateCylinderFrequency(((DecimalSlider)sender).Value);

        private void CellFrequency_Scroll(object sender, EventArgs e)
            => _presenter.UpdateCellFrequency(((DecimalSlider)sender).Value);
        private void CellDisplacement_Scroll(object sender, EventArgs e)
            => _presenter.UpdateCellDisplacement(((DecimalSlider)sender).Value);

        private void NoiseScale_Scroll(object sender, EventArgs e)
            => _presenter.UpdateScale(((DecimalSlider)sender).Value);

        private void Grayscale_CheckedChanged(object sender, EventArgs e)
            => _presenter.SetGrayscale(((CheckBox) sender).Checked);
        private void Invert_CheckedChanged(object sender, EventArgs e)
            => _presenter.SetInverted(((CheckBox)sender).Checked);

        private void RoundCheckBox_CheckedChanged(object sender, EventArgs e)
            => _presenter.SetRounded(((CheckBox)sender).Checked);


        private void MinValue_Scroll(object sender, EventArgs e)
            => _presenter.UpdateMinValue(((DecimalSlider)sender).Value);

        private void MaxValue_Scroll(object sender, EventArgs e)
            => _presenter.UpdateMaxValue(((DecimalSlider)sender).Value);

        private void NoiseMapPreview_Click(object sender, EventArgs e) 
            => _presenter.SetNewSeed();

        #endregion

        #region Lookup indexes

        private Dictionary<Sliders, Control> _sliderControls;
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
        private readonly Dictionary<NoiseType, TabPage> _configTabsIndex = new();
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

        private IndexDictionary<T> IndexListItem<T>(ComboBox.ObjectCollection objectCollection)
        {
            var r = new IndexDictionary<T>();

            foreach (ListItem<T, string> listItem in objectCollection)
            {
                r.Add(listItem.ID, listItem);
            }

            return r;
        }

        private IndexDictionary<NoiseType> _noiseTypesListItemIndex;
        private IndexDictionary<NoiseQuality> _perlinQualitiesListItemIndex;
        private IndexDictionary<NoiseQuality> _billowQualitiesListItemIndex;
        private IndexDictionary<Cell.CellType> _cellTypesListItemIndex;

        private class IndexDictionary<T> : Dictionary<T, ListItem<T, string>>
        {

        }

        #endregion
    }
}
