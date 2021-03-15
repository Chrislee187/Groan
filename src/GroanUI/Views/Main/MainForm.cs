using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GroanUI.Util;

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
            IndexNoiseTypesListItems();

            _presenter.Init();
        }
        
        #region View implementation

        public string ViewTitle { set => Text = value; }

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

        public Size MapSize { set => NoiseMapPreview.Size = value; }

        public Bitmap NoiseMapImage { set => NoiseMapPreview.Image = value; }

        public NoiseType SelectedNoise
        {
            set =>
                NoiseTypeComboBox.SelectedItem =
                    _noiseTypesListItemIndex.TryGetValue(value, out var item)
                        ? item
                        : NoiseTypeComboBox.Items[0];
        }

        public bool GenerateGrayscale { set => Grayscale.Checked = value; }

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
        }

        public void EnableChangeEvents()
        {
            NoiseTypeComboBox.SelectedIndexChanged += NoiseTypeComboBox_SelectedIndexChanged;
            optionTabControl.SelectedIndexChanged += OptionTabControl_SelectedIndexChanged;
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
            => _presenter.SelectNoiseType(((ListItem<NoiseType, string>) NoiseTypeComboBox.SelectedItem).ID);

        private void InvertNoiseMap_CheckedChanged(object sender, EventArgs e) 
            => _presenter.InvertNoise();

        private void OneBitCheckBox_CheckedChanged(object sender, EventArgs e) 
            => _presenter.OneBitToggle();

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
                    }
                }
            }
        }

        private void Frequency_Scroll(object sender, EventArgs e) 
            => _presenter.SetFrequency(((DecimalSlider) sender).Value);

        private void Lacunarity_Scroll(object sender, EventArgs e) 
            => _presenter.SetLacunarity(((DecimalSlider) sender).Value);

        private void Persistance_Scroll(object sender, EventArgs e)
            => _presenter.SetPersistance(((DecimalSlider) sender).Value);

        private void Octaves_Scroll(object sender, EventArgs e)
            => _presenter.SetOctaves((int)((DecimalSlider) sender).Value);

        private void Grayscale_CheckedChanged(object sender, EventArgs e)
            => _presenter.SetGrayscale(((CheckBox) sender).Checked);

        #endregion

        #region Lookup indexes

        private readonly Dictionary<NoiseType, TabPage> _configTabsIndex = new();
        private void IndexConfigTabs()
        {
            foreach (TabPage tab in optionTabControl.TabPages)
            {
                if (tab?.Tag != null)
                {
                    foreach (var t in tab.Tag.ToString()!.Split(",", StringSplitOptions.TrimEntries))
                    {
                        if (Enum.TryParse<NoiseType>(t, out var nt))
                        {
                            _configTabsIndex.Add(nt, tab);
                        }
                    }
                }
            }
        }

        private readonly Dictionary<NoiseType, ListItem<NoiseType, string>> _noiseTypesListItemIndex =  new ();
        private void IndexNoiseTypesListItems()
        {
            foreach (ListItem<NoiseType, string> listItem in NoiseTypeComboBox.Items)
            {
                _noiseTypesListItemIndex.Add(listItem.ID, listItem);
            }
        }

        private Dictionary<Sliders, Control> _sliderControls;
        private void IndexDecimalSliders()
        {
            _sliderControls = new()
            {
                { Sliders.Frequency, Frequency },
                { Sliders.Lacunarity, Lacunarity },
                { Sliders.Persistance, Persistance },
                { Sliders.Octaves, Octaves},
            };
        }

        #endregion
    }
}
