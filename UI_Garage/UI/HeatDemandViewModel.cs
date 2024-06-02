using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.Defaults;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using SkiaSharp;
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
            // Fetch winter heat demand data from your CSV file using source data manager
            var data = GetData.ReadCsvFile("C:\\Users\\admin\\Desktop\\SDU\\S2\\Semester Project 2\\Code Demo\\Semester-Project\\Source_Data_Manager\\data.csv");

            _originalData = data
                .Where(d => d.Date.Month == 12 || d.Date.Month == 1 || d.Date.Month == 2)
                .Select(d => new ObservablePoint(d.Date.ToOADate(), d.HeatDemand)) // Removed .GetValueOrDefault(0.0)
                .ToList();

            FilterData();
        }

        private void FilterData()
        {
            if (_originalData == null || FromDate == null || ToDate == null)
                return;

            var fromDate = FromDate.Value.Date.ToOADate();
            var toDate = ToDate.Value.Date.ToOADate();

            var filteredData = _originalData.Where(d => d.X >= fromDate && d.X <= toDate).ToList();

            WinterHeatDemandSeries.Clear();
            WinterHeatDemandSeries.Add(new LineSeries<ObservablePoint> { Values = new ObservableCollection<ObservablePoint>(filteredData) });
        }

        public string GetHeatDemandDataAsText()
        {
            return string.Join(Environment.NewLine, _originalData.Select(d => $"{DateTime.FromOADate(d.X ?? 0):yyyy-MM-dd}: {d.Y.GetValueOrDefault(0.0)}"));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
