using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using SourceDataManager;

public class ElectricityViewModel : INotifyPropertyChanged
{
    private DateTimeOffset? _fromDate;
    private DateTimeOffset? _toDate;
    private ObservableCollection<ISeries> _winterElectricitySeries;
    private List<ObservablePoint> _originalData; // Add this line

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

    public ObservableCollection<ISeries> WinterElectricitySeries
    {
        get => _winterElectricitySeries;
        set
        {
            _winterElectricitySeries = value;
            OnPropertyChanged();
        }
    }

    public ElectricityViewModel()
    {
        WinterElectricitySeries = new ObservableCollection<ISeries>();
    }

    public void LoadData()
    {
        // Fetch winter electricity data and time from your CSV file using source data manager
        var winterElectricityData = GetData.WinterElectricityPrice();
        var winterElectricityTime = GetData.WinterTime();

        // Ensure the electricity data and time data have the same length
        if (winterElectricityData.Count() != winterElectricityTime.Count)
        {
            throw new InvalidOperationException("The electricity data and time data do not match in length.");
        }
    
        // Parse the data and populate the series
        var series = new LineSeries<ObservablePoint>();
        var chartValues = new ChartValues<ObservablePoint>();

        for (int i = 0; i < winterElectricityData.Count(); i++)
        {
            var date = winterElectricityTime[i].ToOADate();
            chartValues.Add(new ObservablePoint(date, winterElectricityData[i]));
        }

        series.Values = chartValues;
        _originalData = chartValues.ToList();

        WinterElectricitySeries.Clear();
        WinterElectricitySeries.Add(series);
    }

    private void FilterData()
    {
        if (FromDate == null || ToDate == null)
            return;

        var fromDate = FromDate.Value.Date.ToOADate();
        var toDate = ToDate.Value.Date.ToOADate();

        var filteredData = _originalData.Where(d => d.X >= fromDate && d.X <= toDate).ToList();

        WinterElectricitySeries.Clear();
        WinterElectricitySeries.Add(new LineSeries<ObservablePoint> { Values = new ObservableCollection<ObservablePoint>(filteredData) });
    }

    public string GetElectricityDataAsText()
    {
        var electricityData = GetData.WinterElectricityPrice();
        StringBuilder dataText = new StringBuilder();

        foreach (var data in electricityData)
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

