// <script>
(function () {
  'use strict';

  /* ── DOM refs ─────────────────────────────── */
  const form = document.getElementById('loginForm');
  const loginIdEl = document.getElementById('loginId');
  const passwordEl = document.getElementById('password');
  const rememberEl = document.getElementById('rememberMe');
  const btnLogin = document.getElementById('btnLogin');
  const alertBox = document.getElementById('loginAlert');
  const alertMsg = document.getElementById('loginAlertMsg');
  const pwdToggle = document.getElementById('pwdToggle');
  const pwdIcon = document.getElementById('pwdToggleIcon');

  /* ── Password visibility toggle ──────────── */
  pwdToggle.addEventListener('click', () => {
    const isText = passwordEl.type === 'text';
    passwordEl.type = isText ? 'password' : 'text';
    pwdIcon.className = isText
      ? 'fa-regular fa-eye'
      : 'fa-regular fa-eye-slash';
  });

  /* ── Show / hide alert ────────────────────── */
  function showAlert(msg) {
    alertMsg.textContent = msg;
    alertBox.classList.add('show');
  }

  function hideAlert() {
    alertBox.classList.remove('show');
  }

  /* ── Field validation ─────────────────────── */
  function validateField(input, errorEl, message) {
    if (!input.value.trim()) {
      input.classList.add('is-invalid');
      errorEl.textContent = message;
      errorEl.classList.add('show');
      return false;
    }
    input.classList.remove('is-invalid');
    errorEl.classList.remove('show');
    return true;
  }

  /* ── Loading state ────────────────────────── */
  function setLoading(loading) {
    btnLogin.disabled = loading;
    btnLogin.classList.toggle('loading', loading);
  }

  /* ── Form submit ──────────────────────────── */
  form.addEventListener('submit', async (e) => {
    e.preventDefault();
    hideAlert();
    debugger;
    /* Client-side validation */
    const v1 = validateField(
      loginIdEl,
      document.getElementById('loginIdError'),
      'Please enter your username.'
    );
    const v2 = validateField(
      passwordEl,
      document.getElementById('passwordError'),
      'Please enter your password.'
    );

    if (!v1 || !v2) return;

    setLoading(true);

    /* CSRF token */
    const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;

    try {
      const res = await fetch('/Account/Login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'X-Requested-With': 'XMLHttpRequest',
          'RequestVerificationToken': token ?? ''
        },
        body: JSON.stringify({
          loginId: loginIdEl.value.trim(),
          password: passwordEl.value,
          rememberMe: rememberEl.checked
        }),
        credentials: 'same-origin'
      });

      const data = await res.json();

      if (data.success) {
        if (window.EnterpriseLayout) {
          window.EnterpriseLayout.loadContent(data.redirectUrl || '/Home/Index');
        } else {
          window.location.href = data.redirectUrl || '/Home/Index';
        }
      } else {
        showAlert(data.message || 'Invalid username or password.');
        setLoading(false);
        passwordEl.value = '';
        passwordEl.focus();
      }

    } catch (err) {
      showAlert('Connection error. Please try again.');
      setLoading(false);
    }
  });

  /* ── Clear errors on input ────────────────── */
  [loginIdEl, passwordEl].forEach(input => {
    input.addEventListener('input', () => {
      input.classList.remove('is-invalid');
      const errId = input.id + 'Error';
      const errEl = document.getElementById(errId);
      if (errEl) errEl.classList.remove('show');
      hideAlert();
    });
  });

  /* ── Enter key on username → focus password ─ */
  loginIdEl.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') {
      e.preventDefault();
      passwordEl.focus();
    }
  });

  /* ── Forgot password ──────────────────────── */
  document.getElementById('forgotPasswordLink')?.addEventListener('click', (e) => {
    e.preventDefault();
    // TODO: Forgot password page
    alert('Please contact your system administrator to reset your password.');
  });

})();
