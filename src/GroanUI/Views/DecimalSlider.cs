using System;
using System.ComponentModel;
using System.Globalization;
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
                ValueLabel.Text = _sliderConfig.ModelValue.ToString(CultureInfo.InvariantCulture);
            }
        }
        public int Minimum { get => TrackBar.Minimum; set => TrackBar.Minimum = value; }
        public int Maximum { get => TrackBar.Maximum; set => TrackBar.Maximum = value; }
        public int SmallChange { get => TrackBar.SmallChange; set => TrackBar.SmallChange = value; }
        public int LargeChange { get => TrackBar.LargeChange; set => TrackBar.LargeChange = value; }

        private EventHandler<EventArgs> _onScroll;
        private Configuration _sliderConfig;

        [Browsable(true)]
        [Category("Action")]
        public new event EventHandler<EventArgs> Scroll
        {
            add => _onScroll += value;
            remove => _onScroll -= value;
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
            ValueLabel.Text = config.ModelValue.ToString(CultureInfo.InvariantCulture);
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            _sliderConfig.Set(((TrackBar) sender).Value);
            ValueLabel.Text = _sliderConfig.ModelValue.ToString(CultureInfo.InvariantCulture);
            _onScroll?.Invoke(this, e);
        }

        private void ResetValue_DoubleClick(object sender, EventArgs e)
        {
            _sliderConfig.ResetValue();
            TrackBar.Value = _sliderConfig.Value;
            ValueLabel.Text = _sliderConfig.ModelValue.ToString(CultureInfo.InvariantCulture);
            _onScroll?.Invoke(this, e);
        }

        public class Configuration
        {
            private readonly float _modelToSliderFactor;
            public float ModelValue { get; private set; }
            public Sliders Slider { get; }
            private float _initialModelValue;
            public int MinValue { get; }
            public int MaxValue { get; }
            public int SmallStep { get; }
            public int LargeStep { get; }
            public int Value => (int)(ModelValue * _modelToSliderFactor);
            public Configuration(Sliders slider,
                float initialValue,
                float minValue, float maxValue,
                float smallStep = 0.01f, float largeStep = 0.1f,
                int sliderPrecision = 2)
            {
                _modelToSliderFactor = sliderPrecision == 0 ? 1 : (float)Math.Pow(10, sliderPrecision);
                Slider = slider;
                ModelValue = _initialModelValue = initialValue;
                MinValue = (int) (minValue * _modelToSliderFactor);
                MaxValue = (int) (maxValue * _modelToSliderFactor);
                SmallStep = (int) Math.Min(smallStep * _modelToSliderFactor, 1);
                LargeStep = (int)(largeStep * _modelToSliderFactor);
            }

            internal void Set(float modelValue)
            {
                ModelValue = modelValue;
            }
            internal void Set(int controlValue)
            {
                ModelValue = controlValue / _modelToSliderFactor;
            }
            internal void ResetValue()
            {
                ModelValue = _initialModelValue;
            }
        }
    }

}
