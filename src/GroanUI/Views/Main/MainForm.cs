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

            IndexConfigTabs();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _presenter.Init();
            IndexNoiseTypesDropDown();

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
                    _noiseTypesItemIndex.TryGetValue(value, out var item)
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

        public int PerlinScaleLabel
        {
            set => perlinScaleLabel.Text = value.ToString(CultureInfo.InvariantCulture);
        }
        
        public float PerlinAmplitudeLabel
        {
            set => perlinAmplitudeValueLabel.Text = value.ToString(CultureInfo.InvariantCulture);
        }
        public int PerlinAmplitudeScrollValue
        {
            set => perlinAmplitudeHScrollBar.Value = value;
        }

        public float PerlinFrequencyLabel
        {
            set => perlinFrequencyValueLabel.Text = value.ToString(CultureInfo.InvariantCulture);
        }
        public int PerlinFrequencyScrollValue
        {
            set => perlinFrequencyHScrollBar.Value = value;
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
            perlinScale.Scroll -= perlinScale_Scroll;
        }
        public void EnableChangeEvents()
        {
            noiseTypeComboBox.SelectedIndexChanged += noiseTypeComboBox_SelectedIndexChanged;
            optionTabControl.SelectedIndexChanged += optionTabControl_SelectedIndexChanged;
            perlinScale.Scroll += perlinScale_Scroll;
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
                var nt = Enum.Parse<NoiseType>(tab.Tag.ToString()!);

                _presenter.SelectOptionsTab(nt);
            }
        }
        
        private void minThreshold_Scroll(object sender, ScrollEventArgs e) 
            => _presenter.SetMinThreshold(e.NewValue);

        private void maxThreshold_Scroll(object sender, ScrollEventArgs e) 
            => _presenter.SetMaxThreshold(e.NewValue);

        private void perlinScale_Scroll(object sender, ScrollEventArgs e) 
            => _presenter.SetPerlinScale(e.NewValue);

        private void perlinAmplitudeHScrollBar_Scroll(object sender, ScrollEventArgs e) 
            => _presenter.SetPerlinAmplitude(e.NewValue);

        private void perlinFrequencyHScrollBar_Scroll(object sender, ScrollEventArgs e) 
            => _presenter.SetPerlinFrequency(e.NewValue);

        #endregion

        #region Lookup indexes
        
        private readonly Dictionary<NoiseType, TabPage> _configTabsIndex = new();
        private void IndexConfigTabs()
        {
            foreach (TabPage tab in optionTabControl.TabPages)
            {
                if (tab?.Tag != null)
                {
                    var nt = Enum.Parse<NoiseType>(tab.Tag.ToString()!);
                    _configTabsIndex.Add(nt, tab);
                }
            }
        }

        private readonly Dictionary<NoiseType, ListItem<NoiseType, string>> _noiseTypesItemIndex =  new ();
        private void IndexNoiseTypesDropDown()
        {
            foreach (ListItem<NoiseType, string> listItem in noiseTypeComboBox.Items)
            {
                _noiseTypesItemIndex.Add(listItem.ID, listItem);
            }
        }

        #endregion

    }

}
