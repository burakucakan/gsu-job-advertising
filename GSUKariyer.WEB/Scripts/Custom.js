function cvNational(source, args) {
    args.IsValid = args.Value.length == 11;
}

function cvStudentNumber(source, args) {
    args.IsValid = args.Value.length == 8;
}

function cvPassCtrl(source, args) {
    args.IsValid = args.Value.length >= 5;
}

function Login() {   
    $find('LoginModal').show();
}