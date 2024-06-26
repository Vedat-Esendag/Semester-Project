using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using LiveCharts;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using SourceDataManager;

namespace UI
{
    public class HeatDemandViewModel : INotifyPropertyChanged
    {
        private DateTimeOffset? _fromDate;
        private DateTimeOffset? _toDate;
        private ObservableCollection<ISeries> _winterHeatDemandSeries;
        private List<ObservablePoint> _originalData;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTimeOffset? FromDate
        {
            get => _fromDate;
            set
            {
                _fromDate = value;
                OnPropertyChanged();
                FilterData();
            }
        }

        public DateTimeOffset? ToDate
        {
            get => _toDate;
            set
            {
                _toDate = value;
                OnPropertyChanged();
                FilterData();
            }
        }

        public ObservableCollection<ISeries> WinterHeatDemandSeries
        {
            get => _winterHeatDemandSeries;
            set
            {
                _winterHeatDemandSeries = value;
                OnPropertyChanged();
            }
        }

        public HeatDemandViewModel()
        {
            WinterHeatDemandSeries = new ObservableCollection<ISeries>();
            LoadData();
        }

        public void LoadData()
        {
            var winterHeatDemandData = GetData.WinterHeatDemand();
            var winterHeatDemandTime = GetData.WinterTime();

            if (winterHeatDemandData.Count != winterHeatDemandTime.Count)
            {
                throw new InvalidOperationException("The heat demand data and time data do not match in length.");
            }

            var series = new LineSeries<ObservablePoint>();
            var chartValues = new ChartValues<ObservablePoint>();

            for (int i = 0; i < winterHeatDemandData.Count; i++)
            {
                var date = winterHeatDemandTime[i].ToOADate();
                chartValues.Add(new ObservablePoint(date, winterHeatDemandData[i]));
            }

            series.Values = chartValues;
            _originalData = chartValues.ToList();

            WinterHeatDemandSeries.Clear();
            WinterHeatDemandSeries.Add(series);
        }

        private void FilterData()
        {
            if (FromDate == null || ToDate == null)
                return;

            var fromDate = FromDate.Value.Date.ToOADate();
            var toDate = ToDate.Value.Date.ToOADate();

            var filteredData = _originalData.Where(d => d.X >= fromDate && d.X <= toDate).ToList();

            WinterHeatDemandSeries.Clear();
            WinterHeatDemandSeries.Add(new LineSeries<ObservablePoint> { Values = new ObservableCollection<ObservablePoint>(filteredData) });
        }

        public string GetHeatDemandDataAsText()
        {
            var heatDemandData = GetData.WinterHeatDemand();
            StringBuilder dataText = new StringBuilder();

            foreach (var data in heatDemandData)
            {
                dataText.AppendLine(data.ToString());
            }

            return dataText.ToString();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
