// wwwroot/js/chart.js
window.drawPieChart = function () {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var data = google.visualization.arrayToDataTable([
            ['Sport', 'Number of Students'],
            ['Soccer', 5],
            ['Basketball', 7],
            ['Tennis', 4],
            ['No Sports', 4]
        ]);

        var options = {
            title: 'Distribution of Students by Sports'
        };

        var chart = new google.visualization.PieChart(document.getElementById('piechart'));
        chart.draw(data, options);
    }
};

window.drawBarChart = function () {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var data = google.visualization.arrayToDataTable([
            ['Student', 'Score'],
            ['Alice', 85],
            ['Bob', 92],
            ['Charlie', 78],
            ['David', 88],
            ['Eva', 95]
        ]);

        var options = {
            title: 'Math Test Scores',
            hAxis: { title: 'Student' },
            vAxis: { title: 'Score' },
            legend: 'none'
        };

        var chart = new google.visualization.ColumnChart(document.getElementById('barchart'));
        chart.draw(data, options);
    }
};

window.drawLineChart = function () {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var data = google.visualization.arrayToDataTable([
            ['Week', 'Height (cm)'],
            ['1', 5],
            ['2', 9],
            ['3', 15],
            ['4', 20],
            ['5', 28]
        ]);

        var options = {
            title: 'Plant Growth Over Time',
            hAxis: { title: 'Week' },
            vAxis: { title: 'Height (cm)' },
            curveType: 'function',
            legend: { position: 'bottom' }
        };

        var chart = new google.visualization.LineChart(document.getElementById('linechart'));
        chart.draw(data, options);
    }
};

window.drawColumnChart = function () {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var data = google.visualization.arrayToDataTable([
            ['Item', 'Sales'],
            ['Apples', 120],
            ['Bananas', 80],
            ['Cherries', 50],
            ['Dates', 70],
            ['Eggs', 90]
        ]);

        var options = {
            title: 'Sales Comparison for Different Items',
            hAxis: { title: 'Item' },
            vAxis: { title: 'Sales' },
            legend: 'none'
        };

        var chart = new google.visualization.ColumnChart(document.getElementById('columnchart'));
        chart.draw(data, options);
    }
};


function drawBoxWhiskerPlot(min, q1, median, q3, max, selector) {

    // Round the min and max to the nearest multiple of 10
    var roundedMin = Math.floor(min / 10) * 10;
    var roundedMax = Math.ceil(max / 10) * 10;

    // Set the dimensions and margins of the plot (increased size)
    var margin = { top: 10, right: 40, bottom: 40, left: 50 },
        width = 600 - margin.left - margin.right,  // Increased width
        height = 120;  // Increased height

    var container = d3.select(selector);
    container.html('');  // Clear existing content

    // Append the svg object to the specified selector
    var svg = container
        .append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    // Set the X scale based on the rounded min and max values
    var x = d3.scaleLinear()
        .domain([roundedMin, roundedMax])
        .range([0, width]);

    // Add X axis with grid lines at intervals of 1
    svg.append("g")
        .attr("transform", "translate(0," + (height) + ")")  // Place x-axis directly under the box plot
        .call(d3.axisBottom(x)
            .tickValues(d3.range(roundedMin, roundedMax + 1, 1))  // Custom tick values at intervals of 1
            .tickSize(-height)  // Extend ticks as grid lines across the plot area
            .tickFormat((d) => (d % 5 === 0 ? d : ""))  // Display labels only for multiples of 5
        )
        .call(g => g.selectAll(".tick line")  // Select all tick lines
            .attr("stroke-opacity", 0.2)  // Set lighter color for all grid lines
        )
        .call(g => g.selectAll(".tick text")  // Select all tick text elements
            .style("font-size", "16px")  // Set font size to 16 for all labels
        )
        .call(g => g.selectAll(".tick")  // Select all tick elements
            .each(function (d) {  // Iterate over each tick element
                if (d % 5 === 0) {  // Check if the tick value is a multiple of 5
                    d3.select(this).select("line")
                        .attr("stroke-opacity", 0.4)  // Make the line slightly more opaque
                        .attr("stroke-width", 1);  // Keep the stroke width subtle
                }
            })
        )
        .call(g => g.select(".domain").remove());  // Remove the axis line

    // Define a few features for the box plot
    var center = height / 2;  // Centered vertically in available space
    var boxHeight = 50;  // Increased box height

    // Add a horizontal line along the x-axis
    svg.append("line")
        .attr("x1", 0)  // Start from the left edge
        .attr("x2", width)  // End at the right edge
        .attr("y1", height)  // Align with the x-axis
        .attr("y2", height)  // Align with the x-axis
        .attr("stroke", "black")  // Set stroke color for the x-axis line
        .attr("stroke-width", 1);

    // Show the main horizontal line for the whisker plot
    svg.append("line")
        .attr("x1", x(min))
        .attr("x2", x(max))
        .attr("y1", center)
        .attr("y2", center)
        .attr("stroke", "black");

    // Show the box
    svg.append("rect")
        .attr("x", x(q1))
        .attr("y", center - boxHeight / 2)
        .attr("height", boxHeight)
        .attr("width", (x(q3) - x(q1)))
        .attr("stroke", "black")
        .style("fill", "#69b3a2");

    // Show median, min, and max vertical lines
    svg.selectAll("line.vertical")
        .data([min, median, max])
        .enter()
        .append("line")
        .attr("y1", center - boxHeight / 2)
        .attr("y2", center + boxHeight / 2)
        .attr("x1", function (d) { return x(d); })
        .attr("x2", function (d) { return x(d); })
        .attr("stroke", "black");
}
