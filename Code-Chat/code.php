<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <link rel="stylesheet" href="./css/main.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.48.4/codemirror.min.css" />
    <script src="https://codemirror.net/theme/dracula.css"></script>
    <script src="https://cdn.jsdelivr.net/pyodide/v0.18.1/full/pyodide.js"></script>
    <link rel=stylesheet href="https://codemirror.net/theme/monokai.css">
    <title>Code & Chat</title>
</head>

<body>
    <div class="header">
        <img src="./img/codechat-logo.png" alt="Logo" height="100px">
        <div class="linkbalk">
            <div class="link">
                <p>Deel link: <a id="linkDelen" href="https://nisatutucu.nl/">www.nisatutucu.nl</a></p>
                <button id="buttonDelen" class="btn btn-danger rounded-pill" onclick="copyToClipboard()">Kopieer
                    link</button>
            </div>
        </div>
    </div>
    <div class="content">
        <div style="display: flex;">
            <div style="flex: 50;">
                <!-- <img src="./img/screenshot.png" alt="" height="80%"> -->
                <div class="container-fluid bg-light p-3">
                    <div class="d-flex flex-column">
                        <section class="input">
                            <ul class="nav nav-tabs">
                                <li class="nav-item">
                                    <a class="nav-link active" aria-current="page">
                                        <h5>Input</h5>
                                    </a>
                                </li>
                            </ul>
                            <div><textarea id="code" name="code">
                        </textarea>
                            </div>
                        </section>
                        <div class="align-self-center mt-3">
                            <button type="button" class="btn btn-success btn-lg btn-block" onclick="evaluatePython()">
                                <h5>Run</h5>
                            </button>
                        </div>
                        <section class="output">
                            <ul class="nav nav-tabs">
                                <li class="nav-item">
                                    <a class="nav-link active" aria-current="page">
                                        <h5>Output</h5>
                                    </a>
                                </li>
                            </ul>
                            <div>
                                <textarea style="background-color: #272822; color: white;" id="output" name="output" class="w-100" rows="14"></textarea>
                            </div>
                        </section>
                    </div>
                </div>
            </div>
            <div style="order: 2; margin-left: auto;flex: 20; display: flex; flex-direction: column; align-items: end;">
                <div>
                    <span style="background-color: red;" class="dot">Z</span>
                    <span style="background-color: blue;" class="dot">K</span>
                    <span style="background-color: green;" class="dot">L</span>
                    <span style="background-color: purple;" class="dot">P</span>
                </div>
                <div>
                    <span style="background-color: red;" class="dot">Z</span>
                    <span style="background-color: blue;" class="dot">K</span>
                    <span style="background-color: green;" class="dot">L</span>
                    <span style="background-color: purple;" class="dot">P</span>
                </div>
                <div style=" margin-left: auto; margin-top: 60px">
                    <img src="./img/Chat.png" alt="" height="530px">
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.63.3/codemirror.min.js" integrity="sha512-XMlgZzPyVXf1I/wbGnofk1Hfdx+zAWyZjh6c21yGo/k1zNC4Ve6xcQnTDTCHrjFGsOrVicJsBURLYktVEu/8vQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.63.3/mode/python/python.min.js" integrity="sha512-/mavDpedrvPG/0Grj2Ughxte/fsm42ZmZWWpHz1jCbzd5ECv8CB7PomGtw0NAnhHmE/lkDFkRMupjoohbKNA1Q==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="./js/python.js"></script>
    <script src="./js/uniekLink.js"></script>
    <script src="./js/main.js"></script>
</body>

</html>