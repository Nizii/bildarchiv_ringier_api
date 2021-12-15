<template>
  <nav>
    <!-- <img
      class="fixed top-0 left-0 right-0"
      src="UI/assets/img/logo.svg"
      alt="Abstraktes Logo"
    /> -->
    <!-- <a href="/">Menü</a> -->

    <div class="dropdown inline-block relative">
      <button
        class="
          text-white
          font-semibold
          py-2
          px-4
          rounded
          inline-flex
          items-center
        "
      >
        <span>menu</span>
      </button>
      <ul class="dropdown-content absolute hidden pt-1">
        <li>
          <a
            class="
              rounded
              bg-white-200
              hover:bg-zinc-50
              py-2
              px-4
              block
              whitespace-no-wrap
            "
            href="#"
            >Home</a
          >
        </li>
        <li>
          <a
            class="
            rounded
              bg-white-200
              hover:bg-sky-500/50
              py-2
              px-4
              block
              whitespace-no-wrap
            "
            href="#"
            >Impressum</a
          >
        </li>
      </ul>
    </div>
  </nav>
</template>

<style>
.dropdown:hover > .dropdown-content {
  display: block;
}
</style>