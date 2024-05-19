using System;
using System.Collections.Generic;
using System.ComponentModel;
using LiveCharts;
using LiveCharts.Defaults;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using SourceDataManager; // Import your source data manager namespace

namespace UI
{
    public class HeatDemandViewModel : INotifyPropertyChanged
    {
        private IEnumerable<ISeries> _winterHeatDemandSeries;
        private string _winterHeatDemandTime;

        public IEnumerable<ISeries> WinterHeatDemandSeries
        {
            get => _winterHeatDemandSeries;
            set
            {
                _winterHeatDemandSeries = value;
                OnPropertyChanged(nameof(WinterHeatDemandSeries));
            }
        }

        public string WinterHeatDemandTime
        {
            get => _winterHeatDemandTime;
            set
            {
                _winterHeatDemandTime = value;
                OnPropertyChanged(nameof(WinterHeatDemandTime));
            }
        }

        public HeatDemandViewModel()
        {
            LoadData();
        }

        public void LoadData()
        {
            // Fetch winter heat demand data from your CSV file using source data manager
            var winterHeatDemandData = GetData.WinterHeatDemand();
            
            // Parse the data and populate the series
            var series = new LineSeries<ObservablePoint>();
            var chartValues = new ChartValues<ObservablePoint>();

            foreach (var heatDemand in winterHeatDemandData)
            {
                // Assuming your CSV has only heat demand values
                chartValues.Add(new ObservablePoint(chartValues.Count, heatDemand));
            }

            series.Values = chartValues;
            WinterHeatDemandSeries = new List<ISeries> { series };

            // Fetch and set winter heat demand time
            WinterHeatDemandTime = GetData.WinterHeatDemandTime();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
