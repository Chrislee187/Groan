using System;
using System.ComponentModel;
using System.Windows.Forms;
using GroanUI.Views.Main;

namespace GroanUI.Views
{
    [DefaultEvent("Scroll")]
    public partial class DecimalSlider : UserControl
    {
        public string Label { get => Caption.Text; set => Caption.Text = value; }
        public string ToolTipText { get => ToolTip.GetToolTip(Caption); set => SetTooltips(value); }
        public float Value
        {
            get => _sliderConfig.ModelValue;
            set
            {
                if (_sliderConfig == null) return;
                _sliderConfig.Set(value);
                ValueLabel.Text = _sliderConfig.ModelValue.ToString();
            }
        }
        public int Minimum { get => TrackBar.Minimum; set => TrackBar.Minimum = value; }
        public int Maximum { get => TrackBar.Maximum; set => TrackBar.Maximum = value; }
        public int SmallChange { get => TrackBar.SmallChange; set => TrackBar.SmallChange = value; }
        public int LargeChange { get => TrackBar.LargeChange; set => TrackBar.LargeChange = value; }

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
            ToolTip.SetToolTip(Caption, text);
            ToolTip.SetToolTip(ValueLabel, text);
            ToolTip.SetToolTip(TrackBar, text);
        }
        public void Setup(Configuration config)
        {
            _sliderConfig = config;
            TrackBar.Minimum = config.MinValue;
            TrackBar.Maximum = config.MaxValue;
            TrackBar.SmallChange = config.SmallStep;
            TrackBar.LargeChange = config.LargeStep;
            TrackBar.Value = config.Value;
            ValueLabel.Text = config.ModelValue.ToString();
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            _sliderConfig.Set((sender as TrackBar).Value);
            ValueLabel.Text = _sliderConfig.ModelValue.ToString();
            onScroll?.Invoke(this, e);
        }
        public class Configuration
        {
            private readonly float _modelToSliderFactor;
            public float ModelValue { get; private set; }
            public Sliders Slider { get; }
            public float InitialModelValue { get; }
            public int MinValue { get; }
            public int MaxValue { get; }
            public int SmallStep { get; }
            public int LargeStep { get; }
            public int Value => (int)(ModelValue * _modelToSliderFactor);
            public Configuration(Sliders slider,
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
