using System.Text;
using System.Web.Mvc;

namespace dbtest.Util
{
    public static class GoogleChartTool
    {
        public static MvcHtmlString GeneratePieChart(this HtmlHelper html,
                                              string name,
                                              string serviceUrl,
                                              string uniqueId,
                                              string width,
                                              string height,
                                              bool is3D,
                                              bool legendColor)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("   <div id={0}></div>", uniqueId);
            sb.AppendLine("     <script type='text/javascript' src='http://www.google.com/jsapi'></script>");
            sb.AppendLine("     <script type='text/javascript'>");
            sb.AppendLine("         $(document).ready()");
            sb.AppendLine("{");
            sb.AppendLine("             google.load('visualization', '1.0', { 'packages': ['corechart'] });");
            sb.AppendFormat("           google.setOnLoadCallback(drawChart{0});", uniqueId);
            sb.AppendLine("         }");
            sb.AppendFormat("       function drawChart{0}()", uniqueId);
            sb.AppendLine("         {");
            sb.AppendFormat("           $.post('{0}', {{}},", serviceUrl);
            sb.AppendLine("               function (data)");
            sb.AppendLine("               {");
            if (legendColor)
            {
                sb.AppendLine(@" var color = popula(data) ;");
            }

            sb.AppendLine("                     var tdata = new google.visualization.DataTable();");
            sb.AppendLine("                     tdata.addColumn('string', 'SeriesTitle');");
            sb.AppendLine("                     tdata.addColumn('number', 'SeriesValue');");
            sb.AppendLine("                     for (var i = 0; i < data.length; i++) {");
            sb.AppendLine("                         tdata.addRow([data[i].Name, data[i].Value]);");
            sb.AppendLine("                     }");
            sb.AppendLine("                     var options = {");
            if (legendColor)
            {
                sb.AppendLine("               colors : color, ");
            }

            sb.AppendFormat("                       is3D: {0},", is3D.ToString().ToLower());
            sb.AppendLine("                         backgroundColor: { fill: 'transparent' },");
            sb.AppendLine("                         legend: { position: 'right', textStyle: { color: '#D6D6D6'} },");
            sb.AppendFormat("                       chartArea: {{ left: 0, top: 0, width: '{0}', height: '{1}' }},", width, height);
            sb.AppendLine("                         forceIFrame: false");
            sb.AppendLine("                     }");
            sb.AppendFormat("                   var chart = new google.visualization.PieChart(document.getElementById('{0}'));", uniqueId);
            sb.AppendLine("                     chart.draw(tdata, options);");
            sb.AppendLine("               });");
            sb.AppendLine("                 function popula(data) {");
            sb.AppendLine("	                    var colors = new Array(); ");
            sb.AppendLine("	                    for (var i = 0; i < data.length; i++) {");
            sb.AppendLine("                         colors[i] = data[i].Color; ");
            sb.AppendLine("	                    } ");
            sb.AppendLine("	                    return colors; ");
            sb.AppendLine("                 } ");
            sb.AppendLine("         }");
            sb.AppendLine("     </script>");

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
