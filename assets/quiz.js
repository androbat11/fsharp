// Usage: <div class="quiz" data-answer="1"> <p>Question</p> <button>A</button> ... <div class="why">Explanation</div> </div>
document.querySelectorAll('.quiz').forEach(q => {
  const answer = Number(q.dataset.answer);
  const buttons = q.querySelectorAll('button');
  buttons.forEach((b, i) => b.addEventListener('click', () => {
    buttons.forEach(x => x.classList.remove('ok', 'bad'));
    b.classList.add(i === answer ? 'ok' : 'bad');
    if (i === answer) q.querySelector('.why').style.display = 'block';
  }));
});
