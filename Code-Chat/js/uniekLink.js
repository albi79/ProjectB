let id = () => {
  return Math.floor((10000000 + Math.random()) * 900000)
    .toString(16)
    .substring(2);
};

let idLink = id();

function copyToClipboard() {
  const elem = document.createElement("textarea");
  elem.value = document.getElementById("linkDelen").innerText;
  document.body.appendChild(elem);
  elem.select();
  document.execCommand("copy");
  document.body.removeChild(elem);
  //change button text
  document.getElementById("buttonDelen").innerHTML = "Gekopieerd!";
  setTimeout(
    () => (document.getElementById("buttonDelen").innerHTML = "Kopieer link"),
    2000
  );
}
document.addEventListener("DOMContentLoaded", (event) => {
  const uniekLink = document.getElementById("linkDelen");
  uniekLink.innerHTML = window.location.href;
  uniekLink.href = window.location.href;
});

var drag = document.getElementById("drop");

drag.addEventListener("drop", function (ev) {
  // Prevent default behavior (Prevent file from being opened)
  ev.preventDefault();

  if (ev.dataTransfer.items) {
    // Use DataTransferItemList interface to access the file(s)
    for (var i = 0; i < ev.dataTransfer.items.length; i++) {
      // If dropped items aren't files, reject them
      if (ev.dataTransfer.items[i].kind === "file") {
        var file = ev.dataTransfer.items[i].getAsFile();
        console.log("... file[" + i + "].name = " + file.name);
        p = Promise.resolve(ev.dataTransfer.items[i].getAsFile().text());
        p.then(function (value) {
          console.log(value);
          $.ajax({
            type: "POST",
            url: "./php/DBuniekLink.php",
            catche: false,
            dataType: "json",
            data: {
              value: value,
              idLink: idLink,
            },
            error: function (request, status, error) {
              console.log(request.responseText);
              console.log(request);
              window.open(
                "http://localhost/school/projectD/code.php?" +
                  request.responseText,
                "_blank"
              );
            },
            // zodra de ajax geslaagd is
            success: function (response) {
              console.log(response);
              window.open(
                "http://localhost/school/projectD/code.php?" + idLink,
                "_blank"
              );
            },
          });
        });
      }
    }
  } else {
    // Use DataTransfer interface to access the file(s)
    for (var i = 0; i < ev.dataTransfer.files.length; i++) {
      console.log(
        "... file[" + i + "].name = " + ev.dataTransfer.files[i].name
      );
    }
  }
  // window.open("http://localhost/school/projectD/code.php?" + id(), "_blank");
});

drag.addEventListener("dragover", function (ev) {
  console.log("File(s) in drop zone");
  drag.style.backgroundColor = "white";
  drag.innerHTML = "<p>Laat uw bestand los om door te gaan.</p>";
  // Prevent default behavior (Prevent file from being opened)
  ev.preventDefault();
});
drag.addEventListener("dragleave", function (ev) {
  drag.style.backgroundColor = "#B1C2D0";
  drag.innerHTML =
    '<img src="./img/drop.png" alt=""><p><span>Sleep het bestand</span> hierheen &</br> start met coderen</p>';
  // Prevent default behavior (Prevent file from being opened)
  ev.preventDefault();
});
