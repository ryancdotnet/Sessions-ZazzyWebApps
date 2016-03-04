var atlas = atlas || {};

atlas.status = (function () {

    var autoRefreshDelegate = null;

    function onLoaded() {

        $(".refresh-button").click(function (event) {

            //Refresh data
            refreshData();
        });

        refreshData();

        if (autoRefreshDelegate == null) {

            autoRefreshDelegate = autoRefresh;
        }

        autoRefreshDelegate();
    }

    function autoRefresh() {

        setTimeout(refreshData, 1500);
    }

    function refreshData() {

        //Get all processes
        $.ajax({
            url: "http://localhost:50989/Processes/",
            success: loadProcesses
        });
    }

    function loadProcesses(data) {

        for (var i = 0; i < data.length; i++) {

            addOrUpdateProcess(data[i]);
        }

        var processes = atlas.status.viewModel.processes;

        //Remove processes that are deleted
        for (var i = 0; i < processes().length; i++) {

            var found = false;

            for (var d = 0; d < data.length && !found; d++) {

                if (processes()[i].ProcessId() == data[d].ProcessId) {
                    found = true;
                }
            }

            if (!found) {

                //Remove
                processes.remove(function(item){ return item.ProcessId() == processes()[i].ProcessId(); });
                i--;
            }
        }

        if (autoRefreshDelegate) {
            autoRefreshDelegate();
        }
    }

    function makeObservableProcess(process) {
        return {
            ProcessId: ko.observable(process.ProcessId),
            StartDate: ko.observable(process.StartDate),
            EndDate: ko.observable(process.EndDate),
            ProcessStatus: ko.observable(process.ProcessStatus),
            ProcessStatusText: ko.observable("")
        };
    }

    function updateStatus(process) {
        process.ProcessStatusText(function () {
            if (process.ProcessStatus() == 0) return "Pending";
            else if (process.ProcessStatus() == 1) return "Working";
            else if (process.ProcessStatus() == 2) return "Complete";
            else if (process.ProcessStatus() == 3) return "FAIL!";
            else return "Unknown";
        }());
    }

    function addOrUpdateProcess(process) {

        var processes = atlas.status.viewModel.processes;

        var destProcess = null;

        if (processes().length == 0) {

            //Just add it
            destProcess = makeObservableProcess(process);
            processes.push(destProcess);
        }
        else {

            var foundProcess = null;

            for (var i = 0; i < processes().length && foundProcess == null; i++) {

                if (processes()[i].ProcessId() == process.ProcessId) {
                    foundProcess = processes()[i];
                }
            }

            if (foundProcess == null) {

                destProcess = makeObservableProcess(process);
                processes.push(destProcess);
            }
            else {
                //Update
                foundProcess.StartDate(process.StartDate);
                foundProcess.EndDate(process.EndDate);
                foundProcess.ProcessStatus(process.ProcessStatus);

                destProcess = foundProcess;
            }
        }

        updateStatus(destProcess);
    }

    return {

        viewModel: {

            processes: ko.observableArray([])
        },

        methods: {

            onLoaded: onLoaded
        }
    }

})();