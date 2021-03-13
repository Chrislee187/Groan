using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace GroanUI
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
        #region IMainView

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
            set
            {
                noiseTypeComboBox.SelectedItem =
                    _noiseTypesItemIndex.TryGetValue(value, out var item)
                        ? item
                        : noiseTypeComboBox.Items[0];
            }
        }

        public float MinThresholdValue
        {
            set => minThresholdValue.Text = value.ToString(CultureInfo.InvariantCulture);
        }

        public float MaxThresholdValue
        {
            set => maxThresholdValue.Text = value.ToString(CultureInfo.InvariantCulture);
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
        }
        public void EnableChangeEvents()
        {
            noiseTypeComboBox.SelectedIndexChanged += noiseTypeComboBox_SelectedIndexChanged;
            optionTabControl.SelectedIndexChanged += optionTabControl_SelectedIndexChanged;
        }

        #endregion

        private void noiseTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.NoiseTypeSelected(((ListItem<NoiseType, string>) noiseTypeComboBox.SelectedItem).ID);
        }

        private void invertNoiseMap_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.InvertNoise();
        }

        private void optionTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = ((TabControl) sender).SelectedTab;

            if (tab.Tag == null)
            {
                _presenter.SelectDefaultOptionsTab();
            }
            else
            {
                var nt = Enum.Parse<NoiseType>(tab.Tag.ToString());

                _presenter.OptionsTabSelected(nt);
            }
        }


        private readonly Dictionary<NoiseType, TabPage> _configTabsIndex = new();
        private void IndexConfigTabs()
        {
            foreach (TabPage tab in optionTabControl.TabPages)
            {
                if (tab?.Tag != null)
                {
                    var nt = Enum.Parse<NoiseType>(tab.Tag.ToString());
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

        private void minThreshold_Scroll(object sender, ScrollEventArgs e)
        {
            _presenter.SetMinThreshold(e.NewValue);
        }

        private void maxThreshold_Scroll(object sender, ScrollEventArgs e)
        {
            _presenter.SetMaxThreshold(e.NewValue);
        }
    }

}
