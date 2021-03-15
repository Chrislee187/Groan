using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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

            FixScrollBarMaximumValues();
        }

        private void FixScrollBarMaximumValues()
        {
            // TODO: Move these to the DecimalSlider

            // NOTE: There is some weirdness around scroll control Maximum values,
            // see https://stackoverflow.com/questions/2882789/net-vertical-scrollbar-not-respecting-maximum-property

            void Fix(ScrollBar scrollBar)
            {
                scrollBar.Maximum += scrollBar.LargeChange - 1;
            }
            
            Fix(minThreshold);
            Fix(maxThreshold);
            Fix(noiseScale);
        }


        #region View implementation

        public string ViewTitle { set => Text = value; }

        public IEnumerable<ListItem<NoiseType, string>> NoiseTypes
        {
            set
            {
                if (!Equals(noiseTypeComboBox.DataSource, value))
                {
                    noiseTypeComboBox.DataSource = value;
                }
                noiseTypeComboBox.DisplayMember = nameof(ListItem<NoiseType, string>.Value);
            }
        }

        public Size MapSize { set => previewPictureBox.Size = value; }

        public Bitmap NoiseMapImage { set => previewPictureBox.Image = value; }

        public NoiseType SelectedNoise
        {
            set =>
                noiseTypeComboBox.SelectedItem =
                    _noiseTypesListItemIndex.TryGetValue(value, out var item)
                        ? item
                        : noiseTypeComboBox.Items[0];
        }

        public float MinThresholdLabel
        {
            set => minThresholdValue.Text = value.ToString(CultureInfo.InvariantCulture);
        }

        public float MaxThresholdLabel
        {
            set => maxThresholdValue.Text = value.ToString(CultureInfo.InvariantCulture);
        }

        public int MinThreshold
        {
            set => minThreshold.Value = value;
        }

        public int MaxThreshold
        {
            set => maxThreshold.Value = value;
        }

        public float NoiseScale
        {
            set => noiseScale.Value = (int) value * 100;
        }

        public float NoiseScaleLabel
        {
            set => scaleLabel.Text = value.ToString(CultureInfo.InvariantCulture);
        }

        public int XOffset
        {
            set => xOffset.Value = value;
        }

        public int XOffsetLabel
        {
            set => xOffsetLabel.Text = value.ToString();
        }

        public int YOffsetLabel
        {
            set => yOffsetLabel.Text = value.ToString();
        }

        public int YOffset
        {
            set => yOffset.Value = value;
        }

        public void ShowDefaultOptionsTab()
        {
            optionTabControl.SelectedTab = optionTabControl.TabPages[0];
            noiseTypeComboBox.SelectedIndex = 0;
        }

        public void ShowOptionsTabFor(NoiseType noiseType) =>
            optionTabControl.SelectedTab = 
                _configTabsIndex.TryGetValue(noiseType, out var tab) 
                    ? tab 
                    : optionTabControl.TabPages[0];

        public void DisableChangeEvents()
        {
            noiseTypeComboBox.SelectedIndexChanged -= noiseTypeComboBox_SelectedIndexChanged;
            optionTabControl.SelectedIndexChanged -= optionTabControl_SelectedIndexChanged;
            noiseScale.Scroll -= noiseScale_Scroll;
        }

        public void EnableChangeEvents()
        {
            noiseTypeComboBox.SelectedIndexChanged += noiseTypeComboBox_SelectedIndexChanged;
            optionTabControl.SelectedIndexChanged += optionTabControl_SelectedIndexChanged;
            noiseScale.Scroll += noiseScale_Scroll;
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

        private void noiseTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) 
            => _presenter.SelectNoiseType(((ListItem<NoiseType, string>) noiseTypeComboBox.SelectedItem).ID);

        private void invertNoiseMap_CheckedChanged(object sender, EventArgs e) 
            => _presenter.InvertNoise();

        private void oneBitCheckBox_CheckedChanged(object sender, EventArgs e) 
            => _presenter.OneBitToggle();

        private void optionTabControl_SelectedIndexChanged(object sender, EventArgs e)
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

        private void minThreshold_Scroll(object sender, ScrollEventArgs e) 
            => _presenter.SetMinThreshold(e.NewValue);

        private void maxThreshold_Scroll(object sender, ScrollEventArgs e)
        {
            _presenter.SetMaxThreshold(e.NewValue);
        }

        private void noiseScale_Scroll(object sender, ScrollEventArgs e) 
            => _presenter.SetNoiseScale(e.NewValue);

        private void lacunaritySlider_Scroll(object sender, EventArgs e)
        {
            _presenter.SetPerlinLacunarity((sender as DecimalSlider).Value);
        }

        private void perlinFrequency_Scroll(object sender, EventArgs e)
        {
            _presenter.SetPerlinFrequency((sender as DecimalSlider).Value);
        }

        private void xOffset_Scroll(object sender, ScrollEventArgs e)
        {
            _presenter.SetXOffset(e.NewValue);
        }

        private void yOffset_Scroll(object sender, ScrollEventArgs e)
        {
            _presenter.SetYOffset(e.NewValue);
        }

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
            foreach (ListItem<NoiseType, string> listItem in noiseTypeComboBox.Items)
            {
                _noiseTypesListItemIndex.Add(listItem.ID, listItem);
            }
        }

        public enum Sliders
        {
            PerlinFrequency,
            PerlinLacunarity
        }
        private Dictionary<Sliders, Control> _sliderControls;
        private void IndexDecimalSliders()
        {
            _sliderControls = new()
            {
                { Sliders.PerlinFrequency, perlinFrequency },
                { Sliders.PerlinLacunarity, lacunaritySlider },
            };
        }

        #endregion
    }

}
