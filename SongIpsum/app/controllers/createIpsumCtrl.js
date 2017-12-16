app.controller("createIpsumCtrl", ["$http", "$scope", function ($http, $scope) {
    $scope.lyricInfo = [];
    $scope.decadeInfo = [];
    $scope.selectedDecadeInfo = [];

    let getLyrics = () => {
        $http.get("/api/lyric")
            .then((result) => {
                $scope.lyricInfo = result.data;
            }).catch((error) => {
                console.log("getLyrics error", error);
            });
    };

    getLyrics();

    //let getAllDecades = () => {
    //    $http.get("/api/lyric")
    //        .then((result) => {
    //            $scope.decadeInfo = result.data;
    //        }).catch((error) => {
    //            console.log("getAllDecades error", error);
    //        });
    //};

    //getAllDecades();

    let getSelectedDecade = (selectedDecade) => {
        $http.get("/api/lyric/decade/{selectedDecade}")
            .then((result) => {
                $scope.selectedDecadeInfo = result.data;
            }).catch((error) => {
                console.log("getSelectedDecade error", error);
            });
    };




}]);