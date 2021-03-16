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
            => _presenter.UpdateFrequency(((DecimalSlider) sender).Value);

        private void Lacunarity_Scroll(object sender, EventArgs e) 
            => _presenter.UpdateLacunarity(((DecimalSlider) sender).Value);

        private void Persistance_Scroll(object sender, EventArgs e)
            => _presenter.UpdatePersistance(((DecimalSlider) sender).Value);

        private void Octaves_Scroll(object sender, EventArgs e)
            => _presenter.UpdateOctaves((int)((DecimalSlider) sender).Value);
        
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
        {
            _presenter.SetNewSeed();
        }
        #endregion

        #region Lookup indexes

        private Dictionary<Sliders, Control> _sliderControls;
        private void IndexDecimalSliders()
        {
            _sliderControls = new()
            {
                { Sliders.Frequency, Frequency },
                { Sliders.Lacunarity, Lacunarity },
                { Sliders.Persistance, Persistance },
                { Sliders.Octaves, Octaves },
                { Sliders.MinValue, MinValue },
                { Sliders.MaxValue, MaxValue },
                { Sliders.Scale, NoiseScale },
            };
        }
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


        #endregion

    }
}
