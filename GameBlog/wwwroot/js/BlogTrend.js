$(document).ready(function () {



    $.ajax({
        type:'GET',
        contentType: 'application/json; charset=utf-8',
        url: 'api/Chart/GetChart',
        success: function (response) {
            let data = response;
            
            let traces = [];

            let data1 = {
                y: [2,3,4,5,2,3,11,8,9,12,0,1],
                x: data.xaxis,
                name: 'Previous Year',
                type: 'bar'
            };

            traces.push(data1);
            // Data for the bar chart
            let data2 = {
                x: data.xaxis,
                y: data.yaxis,
                type: 'bar',
                name: 'Current Year'
            };

            traces.push(data2);


            let trendTrace = {
                x: data.xaxis,
                y: data.yaxis,
                type: 'scatter',
                mode: 'lines',
                name: 'Trendline',
                line: { color: 'red', width: 2 }
            };

            traces.push(trendTrace);
            // Layout configuration
            let layout = {
                title: 'Blogs per Year',
                xaxis: { title: 'Month' },
                yaxis: { title: 'Count' }
            };

            // Render the chart
            Plotly.newPlot('chart', traces, layout, { responsive: true });

        },
        error: function (xhr, status, error) {
            
        }
    });

  
});