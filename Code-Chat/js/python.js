const output = document.getElementById("output");

const editor = CodeMirror.fromTextArea(document.getElementById("code"), {
  mode: {
    name: "python",
    version: 3,
    singleLineStringErrors: false,
  },
  lineNumbers: true,
  indentUnit: 4,
  matchBrackets: true,
  theme: "monokai",
});

editor.setValue(`print("Hello World!")`);
output.value = "Initializing...\n";

async function main() {
  let pyodide = await loadPyodide({
    indexURL: "https://cdn.jsdelivr.net/pyodide/v0.18.1/full/",
    stdout: (text) => {
      output.value += text + "\n";
    },
    stderr: (text) => {
      output.value += text + "\n";
    },
  });
  // Pyodide ready
  return pyodide;
}

let pyodideReadyPromise = main();

function addToOutput(s) {
  return;
}

async function evaluatePython() {
  let pyodide = await pyodideReadyPromise;

  try {
    console.log(editor.getValue());
    let output = pyodide.runPython(editor.getValue());
    addToOutput(output);
  } catch (err) {
    addToOutput(err);
  }
}
