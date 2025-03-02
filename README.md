# Design Patterns Workshop

This codebase shows a working implementation of a few known design patterns to create a Point of Sale (POS) system. This is not intended as an example of best practices or necessarily a realistic implementation of these ideas (some applications of design patterns in this codebase are simply _overkill_ for the actual needs of the example) - the purpose here is to allow you to explore a new codebase by identifying the patterns in use and hopefully getting to make a quick start at introducing changes of your own.

## Practice

I've included three suggested challenges that will require you to read and comprehend the existing codebase in order to apply simple changes.

As always in coding, there are no right answers here. These challenges can be solved by working with the existing patterns, applying new ones, or by applying appropriate deviations to these patterns.

<hr>

Use this repo template to create your own sandbox and feel free to deviate from the suggested challenges.

_However_, keep in mind the **[open-closed principle](https://stackify.com/solid-design-open-closed-principle/)** when working through these challenges and consider how the known design patterns can help you. In other words, try to extend the existing code, rather than change it, where possible.

<details>
  <summary>
    Challenge 1
  </summary>
  Imagine that a new requirement has been communicated for POS operators to be able to undo the adding of a discount to any purchase. Refactor the code to allow your discount strategies to be handled as commands.
</details>

<br>

<details>
  <summary>
    Challenge 2
  </summary>
  Suppose a new discount strategy is needed that will require an additional argument being passed to the strategy module. For example, a discount available for loyalty clients that only applies to purchases on the clients' birthday.<br>
  This `Birthday Discount Strategy` would need to receive the value it's valid date (the clients' birthday) and be able to match it to the current date to define whether a discount should be applied.
</details>

<br>

<details>
  <summary>
    Challenge 3
  </summary>
  Suppose a new criteria has been set for POS operators to be able to trigger the `Undo` and `Redo` actions through keyboard shortcuts. Bind the existing commands to any keyboard shortcuts of your choosing.
</details>

<br>

Have fun 🪲