using System;
using System.ComponentModel;
using System.Windows.Forms;
using GroanUI.Views.Main;

namespace GroanUI.Views
{
    [DefaultEvent("Scroll")]
    public partial class DecimalSlider : UserControl
    {
        public string Label { get => label.Text; set => label.Text = value; }
        public string ToolTipText { get => toolTip1.GetToolTip(label); set => SetTooltips(value); }
        public float Value
        {
            get => _sliderConfig.ModelValue;
            set
            {
                if (_sliderConfig == null) return;
                _sliderConfig.Set(value);
                valueLabel.Text = _sliderConfig.ModelValue.ToString();
            }
        }

        public int Minimum { get => slider.Minimum; set => slider.Minimum = value; }
        public int Maximum { get => slider.Maximum; set => slider.Maximum = value; }
        public int SmallChange { get => slider.SmallChange; set => slider.SmallChange = value; }
        public int LargeChange { get => slider.LargeChange; set => slider.LargeChange = value; }

        private EventHandler<EventArgs> onScroll;
        private Configuration _sliderConfig;


        [Browsable(true)]
        [Category("Action")]
        public new event EventHandler<EventArgs> Scroll
        {
            add
            {
                onScroll += value;
            }
            remove
            {
                onScroll -= value;
            }
        }
        public DecimalSlider()
        {
            InitializeComponent();

        }

        private void SetTooltips(string text)
        {
            toolTip1.SetToolTip(label, text);
            toolTip1.SetToolTip(valueLabel, text);
            toolTip1.SetToolTip(slider, text);
        }
        public void Setup(Configuration config)
        {
            _sliderConfig = config;
            slider.Minimum = config.MinValue;
            slider.Maximum = config.MaxValue;
            slider.SmallChange = config.SmallStep;
            slider.LargeChange = config.LargeStep;
            slider.Value = config.Value;
            valueLabel.Text = config.ModelValue.ToString();
        }

        private void trackbar_Scroll(object sender, EventArgs e)
        {
            _sliderConfig.Set((sender as TrackBar).Value);
            valueLabel.Text = _sliderConfig.ModelValue.ToString();
            onScroll?.Invoke(this, e);
        }
        public class Configuration
        {
            private readonly float _modelToSliderFactor;
            public float ModelValue { get; private set; }
            public MainForm.Sliders Slider { get; }
            public float InitialModelValue { get; }
            public int MinValue { get; }
            public int MaxValue { get; }
            public int SmallStep { get; }
            public int LargeStep { get; }
            public int Value => (int)(ModelValue * _modelToSliderFactor);
            public Configuration(MainForm.Sliders slider,
                float initialValue,
                int minValue, int maxValue,
                float modelToSliderFactor,
                int smallStep = 1, int largeStep = 10)
            {
                _modelToSliderFactor = modelToSliderFactor;
                Slider = slider;
                ModelValue = InitialModelValue = initialValue;
                MinValue = minValue;
                MaxValue = maxValue;
                SmallStep = smallStep;
                LargeStep = largeStep;
            }

            public void Set(float modelValue)
            {
                ModelValue = modelValue;
            }
            public void Set(int controlValue)
            {
                ModelValue = controlValue / _modelToSliderFactor;
            }
        }

    }

}
