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
          text-white-700
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
      <ul class="dropdown-content absolute hidden text-gray-700 pt-1">
        <li>
          <a
            class="
              rounded-t
              bg-gray-200
              hover:bg-gray-400
              py-2
              px-4
              block
              whitespace-no-wrap
            "
            href="#"
            >Option 1</a
          >
        </li>
        <li>
          <a
            class="
              bg-gray-200
              hover:bg-gray-400
              py-2
              px-4
              block
              whitespace-no-wrap
            "
            href="#"
            >Option 2</a
          >
        </li>
        <li class="dropdown">
          <a
            class="
              bg-gray-200
              hover:bg-gray-400
              py-2
              px-4
              block
              whitespace-no-wrap
            "
            href="#"
            >Option 3 🠞</a
          >
          <ul
            class="
              dropdown-content
              absolute
              hidden
              text-gray-700
              pl-5
              ml-24
              -mt-10
            "
          >
            <li>
              <a
                class="
                  bg-gray-200
                  hover:bg-gray-400
                  py-2
                  px-4
                  block
                  whitespace-no-wrap
                "
                href="#"
                >Option 3-1</a
              >
            </li>
            <li>
              <a
                class="
                  bg-gray-200
                  hover:bg-gray-400
                  py-2
                  px-4
                  block
                  whitespace-no-wrap
                "
                href="#"
                >Option 3-2</a
              >
            </li>
          </ul>
        </li>
        <li>
          <a
            class="
              rounded-b
              bg-gray-200
              hover:bg-gray-400
              py-2
              px-4
              block
              whitespace-no-wrap
            "
            href="#"
            >Option 4</a
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